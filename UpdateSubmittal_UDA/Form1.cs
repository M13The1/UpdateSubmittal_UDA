using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace UpdateSubmittal_UDA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            RunTekla();
        }

        private void RunTekla()
        {
            try
            {
                Model model = new Model();

                if (!model.GetConnectionStatus())
                {
                    MessageBox.Show("No active Tekla model found.");
                    return;
                }

                string type = txtType.Text.Trim();
                string submittalNumber = txtSubmittalNumber.Text.Trim();
                DateTime teklaEpoch = new DateTime(1970, 1, 1);
                long submittalDate = new DateTimeOffset(dtSubmittalDate.Value.ToUniversalTime()).ToUnixTimeSeconds();

                Tekla.Structures.Model.UI.ModelObjectSelector selector = new Tekla.Structures.Model.UI.ModelObjectSelector();
                ModelObjectEnumerator enumerator = selector.GetSelectedObjects();

                if (enumerator == null || !enumerator.MoveNext())
                {
                    MessageBox.Show("No objects selected.");
                    return;
                }

                enumerator.Reset();

                int count = 0;

                while (enumerator.MoveNext())
                {
                    Part part = enumerator.Current as Part;
                    if (part == null) continue;

                    string pos = "";
                    int qty = 0;
                    double length = 0.0;
                    string profile = "";
                    double height = 0.0;

                    part.GetReportProperty("PART_POS", ref pos);
                    part.GetReportProperty("MODEL_TOTAL", ref qty);
                    part.GetReportProperty("LENGTH", ref length);
                    part.GetReportProperty("HEIGHT", ref height);


                    if (part.Profile != null)
                        profile = part.Profile.ProfileString;
                    profile = Profile.FormatProfileString(profile);

                    ContourPlate contourPlate = part as ContourPlate;
                    if (contourPlate != null)
                    {
                        profile = profile + "X" + toFractionalInches(height);
                    }

                    profile = profile.Replace("\"", " ");


                    string prefix = type.ToUpper() == "OFA" ? "OFA_" : "IFC_";

                    part.SetUserProperty(prefix + "POS", pos ?? "");
                    part.SetUserProperty(prefix + "QTY", qty.ToString() ?? "0");
                    part.SetUserProperty(prefix + "PROFILE", profile ?? "");
                    part.SetUserProperty(prefix + "LENGTH", length.ToString("F2") ?? "0");
                    part.SetUserProperty("SUBMITTAL_NOTE", submittalNumber);

                    string date = type.ToUpper() == "OFA" ? "APPROVAL_SENT" : "SHOP_ISSUE";
                    part.SetUserProperty(date, submittalDate);

                    if (type.ToUpper() == "IFC")
                        part.SetUserProperty("OBJECT_LOCKED", 1);

                    if (part.Identifier.ID != 0)
                        count++;
                }

                model.CommitChanges();

                MessageBox.Show($"Updated {count} parts successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private string toFractionalInches(double width)
        {
            double totalInches = width / 25.4;

            //Get whole inch part
            int wholeInches = (int)Math.Floor(totalInches);

            // Get the fractional part
            double fractionalPart = totalInches - wholeInches;

            // Define common fractions (denominator up to 16 for precision)
            int[] denominators = { 2, 4, 8, 16 };
            string fractionString = "";

            // Find the closest fraction
            double minDifference = double.MaxValue;
            foreach (int denominator in denominators)
            {
                int numerator = (int)Math.Round(fractionalPart * denominator);
                double approx = (double)numerator / denominator;
                double diff = Math.Abs(fractionalPart - approx);

                if (diff < minDifference)
                {
                    minDifference = diff;
                    if (numerator == 0)
                        fractionString = "";
                    else
                        fractionString = $"{numerator}/{denominator}";

                }
            }

            if (string.IsNullOrEmpty(fractionString))
                return $"{wholeInches}";
            else if (wholeInches == 0)
                return $"{fractionString}";
            else
                return $"{wholeInches} {fractionString}";
        }

        public static void LoadTeklaAssemblies()
        {
            // Tekla sets XS_SYSTEM to point to the system folder
            string xsSystem = Environment.GetEnvironmentVariable("XS_SYSTEM");

            if (string.IsNullOrEmpty(xsSystem))
            {
                throw new InvalidOperationException("XS_SYSTEM environment variable is not set. Tekla may not be installed or environment not initialized.");
            }

            string binPath = Path.Combine(xsSystem, "bin");

            // Hook into AssemblyResolve to load Tekla assemblies dynamically
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string assemblyName = new AssemblyName(args.Name).Name + ".dll";
                string assemblyPath = Path.Combine(binPath, assemblyName);

                if (File.Exists(assemblyPath))
                {
                    
                    return System.Reflection.Assembly.LoadFrom(assemblyPath);
                }

                return null; // fallback if not found
            };
        }
    }
}