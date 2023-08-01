using System.Diagnostics;

namespace ThrawnStartupScreen
{
    public class ConfigInfo
    {
        Color DotsColor = Color.Black;
    }

    public partial class LoadingScreen : Form
    {
        public Process? ProgramProcess;

        //For UI Control
        public delegate void aDelegate();
        public aDelegate UpdateFromAnotherThread;
        public string dots = "";

        public LoadingScreen()
        {
            InitializeComponent();
            SetRandomBackgroundImage();
            StyleFormFromConfigFile();
            UpdateFromAnotherThread = new aDelegate(UpdateUI);
            new Thread(new ThreadStart(this.StartProgramScript)).Start();
        }

        private void CancelLoadButton_Click(object sender, EventArgs e)
        {
            if (ProgramProcess != null)
            {
                ProgramProcess.Kill(true);
                //Process.Start(@"C:\Workspace\ThrawnStartupScreen\Kill Thrawn.bat"); // Another way
                Application.Exit();
            }
        }
        private void MakeDotsMove()
        {
            try
            {
                int i;
                while (true)
                {
                    dots = "";
                    this.Invoke(UpdateFromAnotherThread);
                    Thread.Sleep(500);
                    for (i = 0; i < 3; i++)
                    {
                        dots += ".";
                        try
                        {
                            this.Invoke(UpdateFromAnotherThread);
                        }
                        catch { return; }
                        Thread.Sleep(500);
                    }

                }
            }
            catch { return; }
        }

        public void StartProgramScript()
        {
            string? BatFileName = FindAnyBatFile();
            if (BatFileName == null) { Application.Exit(); return; }

            new Thread(new ThreadStart(MakeDotsMove)).Start();

            ProgramProcess = new Process();
            ProgramProcess.StartInfo.CreateNoWindow = true;
            ProgramProcess.StartInfo.RedirectStandardOutput = true;
            ProgramProcess.StartInfo.FileName = BatFileName;
            ProgramProcess.Start();
            string? output = ProgramProcess.StandardOutput.ReadLine();
            while (output != null && !output.Contains("ProgramLaunchComplete")) output = ProgramProcess.StandardOutput.ReadLine();
            Application.Exit();
        }

        public void UpdateUI()
        {
            LoadingDots.Text = dots;
        }

        public static string? FindAnyBatFile()
        { //Chat GPT
            string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] batFiles = Directory.GetFiles(outputDirectory, "*.bat");

            if (batFiles.Length == 1)
            {
                return batFiles[0];
            }
            else if (batFiles.Length > 1)
            {
                // More than one .bat file found, show an error message
                MessageBox.Show("Multiple .bat files found in the output directory. Please ensure there is only one .bat file.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // No .bat file found, show an error message
                MessageBox.Show("No .bat files found in the output directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return null if no .bat file or multiple .bat files are found
            return null;
        }


        private void SetRandomBackgroundImage()
        { //Chat GPT
            string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] pngFiles = Directory.GetFiles(outputDirectory, "*.png");

            if (pngFiles.Length > 0)
            {
                try
                {
                    // Create a random number generator
                    Random random = new Random();

                    // Get a random index to pick a random image from the array
                    int randomIndex = random.Next(0, pngFiles.Length);

                    // Load the randomly selected image from the output directory
                    Image backgroundImage = Image.FromFile(pngFiles[randomIndex]);

                    // Set the image as the background image of the form
                    this.BackgroundImage = backgroundImage;

                    // Adjust the background image layout mode if needed
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions related to loading the image
                    MessageBox.Show($"Error loading the background image: {ex.Message}");
                }
            }
            else
            {
                // Handle the case when no .PNG files are found in the output directory
                MessageBox.Show("No .PNG files found in the output directory.");
            }
        }

        private void StyleFormFromConfigFile()
        { //Chat GPT
            string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configFile = Path.Combine(outputDirectory, "StyleConfig.txt");

            if (File.Exists(configFile))
            {
                try
                {
                    // Read the content of the config file
                    string[] lines = File.ReadAllLines(configFile);

                    // Parse the style information
                    Color backgroundColor = Color.White;
                    Color textColor = Color.Black;
                    Color labelTextColor = Color.Black;

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();

                            switch (key)
                            {
                                case "ButtonBackgroundColor":
                                    backgroundColor = Color.FromName(value);
                                    break;
                                case "ButtonTextColor":
                                    textColor = Color.FromName(value);
                                    break;
                                case "LabelTextColor":
                                    labelTextColor = Color.FromName(value);
                                    break;
                                default:
                                    // Handle unrecognized keys if needed
                                    break;
                            }
                        }
                    }

                    CancelLoadButton.BackColor = backgroundColor;
                    CancelLoadButton.ForeColor = textColor;
                    LoadingDots.ForeColor = labelTextColor;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions related to reading the config file or applying styles
                    MessageBox.Show($"Error reading the config file: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Handle the case when the config file is not found in the output directory
                MessageBox.Show("Config file not found in the output directory.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}