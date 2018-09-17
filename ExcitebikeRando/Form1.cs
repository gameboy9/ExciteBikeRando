using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcitebikeRando
{
    public partial class Form1 : Form
    {
        bool loading = true;
        byte[] romData;
        byte[] romData2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSeed.Text = (DateTime.Now.Ticks % 2147483647).ToString();

            try
            {
                using (TextReader reader = File.OpenText("lasteb.txt"))
                {
                    txtFlags.Text = reader.ReadLine();
                    txtFileName.Text = reader.ReadLine();

                    determineChecks(null, null);

                    runChecksum();
                    loading = false;
                }
            }
            catch
            {
                // ignore error
                loading = false;
                cboChallengeLaps.SelectedIndex = 0;
                cboExcitebikeLaps.SelectedIndex = 1;
                cboBikeSpeed.SelectedIndex = 5;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = File.CreateText("lasteb.txt"))
            {
                writer.WriteLine(txtFlags.Text);
                writer.WriteLine(txtFileName.Text);
            }
        }

        private void runChecksum()
        {
            try
            {
                using (var md5 = SHA1.Create())
                {
                    using (var stream = File.OpenRead(txtFileName.Text))
                    {
                        lblSHAChecksum.Text = BitConverter.ToString(md5.ComputeHash(stream)).ToLower().Replace("-", "");
                    }
                }
            }
            catch
            {
                lblSHAChecksum.Text = "????????????????????????????????????????";
            }
        }

        private bool loadRom(bool extra = false)
        {
            try
            {
                romData = File.ReadAllBytes(txtFileName.Text);
                if (extra)
                    romData2 = File.ReadAllBytes(txtCompare.Text);
            }
            catch
            {
                MessageBox.Show("Empty file name(s) or unable to open files.  Please verify the files exist.");
                return false;
            }
            return true;
        }

        private void saveRom()
        {
            string options = "";
            string finalFile = Path.Combine(Path.GetDirectoryName(txtFileName.Text), "ExciteBike_" + txtSeed.Text + "_" + txtFlags.Text + ".nes");
            File.WriteAllBytes(finalFile, romData);
            lblStatus.Text = "ROM hacking complete!  (" + finalFile + ")";
            txtCompare.Text = finalFile;
        }

        private void btnNewSeed_Click(object sender, EventArgs e)
        {
            txtSeed.Text = (DateTime.Now.Ticks % 2147483647).ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
                runChecksum();
            }
        }

        private void determineFlags(object sender, EventArgs e)
        {
            if (loading)
                return;

            string flags = "";
            int number = (chkObstacles.Checked ? 1 : 0) + (chkColors.Checked ? 2 : 0) + (chkVSTracks.Checked ? 4 : 0) + (chkVSOpponents.Checked ? 8 : 0) + (chkLoopTrack1.Checked ? 16 : 0);
            flags += convertIntToChar(number);

            flags += cboChallengeLaps.SelectedIndex < 9 ? (cboChallengeLaps.SelectedIndex + 1).ToString() : cboChallengeLaps.SelectedIndex == 9 ? "R" : cboChallengeLaps.SelectedIndex == 10 ? "L" : "H";
            flags += cboExcitebikeLaps.SelectedIndex < 9 ? (cboExcitebikeLaps.SelectedIndex + 1).ToString() : cboExcitebikeLaps.SelectedIndex == 9 ? "R" : cboExcitebikeLaps.SelectedIndex == 10 ? "L" : "H";
            flags += cboBikeSpeed.SelectedIndex.ToString();

            txtFlags.Text = flags;
        }

        private void determineChecks(object sender, EventArgs e)
        {
            if (txtFlags.Text.Length != 4) return;
            loading = true;
            string flags = txtFlags.Text;
            int number = convertChartoInt(Convert.ToChar(flags.Substring(0, 1)));
            chkObstacles.Checked = (number % 2 == 1);
            chkColors.Checked = (number % 4 >= 2);
            chkVSTracks.Checked = (number % 8 >= 4);
            chkVSOpponents.Checked = (number % 16 >= 8);
            chkLoopTrack1.Checked = (number % 32 >= 16);

            string laps = flags.Substring(1, 1);
            if (laps == "R")
                cboChallengeLaps.SelectedIndex = 9;
            else if (laps == "L")
                cboChallengeLaps.SelectedIndex = 10;
            else if (laps == "H")
                cboChallengeLaps.SelectedIndex = 11;
            else
                cboChallengeLaps.SelectedIndex = Convert.ToInt32(laps) - 1;

            laps = flags.Substring(2, 1);
            if (laps == "R")
                cboExcitebikeLaps.SelectedIndex = 9;
            else if (laps == "L")
                cboExcitebikeLaps.SelectedIndex = 10;
            else if (laps == "H")
                cboExcitebikeLaps.SelectedIndex = 11;
            else
                cboExcitebikeLaps.SelectedIndex = Convert.ToInt32(laps) - 1;

            laps = flags.Substring(3, 1);
            cboBikeSpeed.SelectedIndex = Convert.ToInt32(laps);

            loading = false;
        }

        private string convertIntToChar(int number)
        {
            if (number >= 0 && number <= 9)
                return number.ToString();
            if (number >= 10 && number <= 35)
                return Convert.ToChar(55 + number).ToString();
            if (number >= 36 && number <= 61)
                return Convert.ToChar(61 + number).ToString();
            if (number == 62) return "!";
            if (number == 63) return "@";
            return "";
        }

        private int convertChartoInt(char character)
        {
            if (character >= Convert.ToChar("0") && character <= Convert.ToChar("9"))
                return character - 48;
            if (character >= Convert.ToChar("A") && character <= Convert.ToChar("Z"))
                return character - 55;
            if (character >= Convert.ToChar("a") && character <= Convert.ToChar("z"))
                return character - 61;
            if (character == Convert.ToChar("!")) return 62;
            if (character == Convert.ToChar("@")) return 63;
            return 0;
        }

        private void cmdRandomize_Click(object sender, EventArgs e)
        {
            try
            {
                loadRom();
                expandRom();
                Random r1 = new Random(Convert.ToInt32(txtSeed.Text));
                showSpeedAndScore();
                changeLaps(r1);
                randomizeBikeSpeed(r1);
                if (chkObstacles.Checked) randomizeObstacles(r1);
                if (chkColors.Checked) randomizeColors(r1);
                if (chkVSTracks.Checked) createVSSetup();
                if (chkVSOpponents.Checked) alternateOpponents();
                if (chkLoopTrack1.Checked) loopToTrack1();
                saveRom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
            }
        }

        private void loopToTrack1()
        {
            byte[] romPlugin =
            {
                0xa5, 0x43,
                0xc9, 0x04,
                0xd0, 0x17,
                0xa9, 0x00,
                0x85, 0x43,
                0xee, 0xf3, 0x03,
                0xad, 0xf3, 0x03,
                0x4a,
                0xb0, 0x0e,
                0xad, 0xf8, 0x03,
                0x4a,
                0xf0, 0x08,
                0x8d, 0xf8, 0x03,
                0x38,
                0xb0, 0x02,
                0xe6, 0x43,
                0x60
            };

            for (int lnI = 0; lnI < romPlugin.Length; lnI++)
                romData[0xb10 + lnI] = romPlugin[lnI];

            byte[] romPlugin2 =
            {
                0x20, 0x00, 0x8b,
                0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea, 0xea
            };

            for (int lnI = 0; lnI < romPlugin2.Length; lnI++)
                romData[0x4b60 + lnI] = romPlugin2[lnI];
        }

        private void showSpeedAndScore()
        {
            // ... now take the speed in 0x94 + 0x90 and turn it into text, then place it into 0x31c
            byte[] romPlugin = {
                0xa9, 0x00,
                0x8d, 0x1f, 0x03,
                0x8d, 0x20, 0x03,
                0x8d, 0x21, 0x03,
                0xa5, 0x90,
                0x8d, 0x11, 0x06,
                0xa5, 0x94,
                0x8d, 0x10, 0x06, // If high byte is 0...
                0xf0, 0x13, // Jump to next digit
                0xee, 0x20, 0x03, // Increase hundreds digit
                0xad, 0x11, 0x06,
                0x38,
                0xe9, 0x64, // Decrease low byte by 100.
                0x8d, 0x11, 0x06, // Store low byte
                0xb0, 0xf2, // Skip reduction if we didn't underflow
                0xce, 0x10, 0x06, // Decrease high byte
                0xd0, 0xed, // If still greater than 1, repeat the process
                0xad, 0x11, 0x06,
                0xc9, 0x64,
                0x90, 0x0e, // If less than 100, skip.
                0xee, 0x20, 0x03, // Increase hundreds digit
                0xad, 0x11, 0x06,
                0x38,
                0xe9, 0x64, // Decrease low byte by 100.
                0x8d, 0x11, 0x06, // Store low byte
                0xd0, 0xee, // Repeat comparison
                // Repeat for 10s
                0xc9, 0x0a,
                0x90, 0x0e, // If less than 10, skip.
                0xee, 0x21, 0x03, // Increase tens digit
                0xad, 0x11, 0x06,
                0x38,
                0xe9, 0x0a, // Decrease low byte by 10.
                0x8d, 0x11, 0x06, // Store low byte
                0xd0, 0xee, // Repeat comparison
                0xad, 0x20, 0x03,
                0xc9, 0x0a,
                0x90, 0x09, // If the hundreds are less than 10, skip.  Otherwise, have to set thousands.
                0x38,
                0xe9, 0x0a,
                0x8d, 0x20, 0x03,
                0xee, 0x1f, 0x03,
                // And now scoring!  30 points / each 64 KPH, 10 points if remainder is > 32 KPH.
                0xa5, 0xfc, // Load 0xfc - the pause state
                0xf0, 0x2c, // BEQ +44 bytes
                0x18, // Clear carry
                0xa5, 0x94, // LDA $94
                0x0a, // ASL
                0x65, 0x94, // ADC $94 (so triple)
                0x6d, 0x2f, 0x03, // ADC $032F
                0x8d, 0x2f, 0x03, // STA $032F
                0xa5, 0x90, // LDA $90
                0xc9, 0x80, // CMP #80
                0x90, 0x03, // BCC +03
                0xee, 0x2f, 0x03, // INC $032F
                0xa2, 0x07, // LDX $07 <------
                0xbd, 0x28, 0x03, // LDA $0328, X <------ (BNE -21/-12)
                0xc9, 0x0a, // CMP #0A
                0x90, 0x08, // BCC +08
                0xfe, 0x27, 0x03, // INC $0327
                0x38, // Set carry
                0xe9, 0x0a, // SBC #0A
                0xd0, 0xf4, // BNE -12 bytes
                0x9d, 0x28, 0x03, // STA $0328, X <------ (BCC +08)
                0xca, // Decrease X
                0xd0, 0xeb, // BNE -21 bytes
                0x20, 0xf4, 0xd0, // JSR $D0F4
                0x60, // RTS
            };

            for (int lnI = 0; lnI < romPlugin.Length; lnI++)
                romData[0x910 + lnI] = romPlugin[lnI];

            romPlugin = new byte[] { 0x20, 0x00, 0x89 };
            for (int lnI = 0; lnI < romPlugin.Length; lnI++)
                romData[0x5189 + lnI] = romPlugin[lnI];

            romPlugin = new byte[]
            {
                // First carry over what we're skipping... whatever that is
                0xa6, 0x45,
                0xbd, 0xf6, 0xc0,
                0x85, 0x00,
                0xbd, 0x11, 0xc1,
                0x85, 0x01,

                0xa9, 0x23,
                0x8d, 0x1c, 0x03,
                0xa9, 0x96,
                0x8d, 0x1d, 0x03,
                0xa9, 0x07,
                0x8d, 0x1e, 0x03,

                0xa9, 0x35,
                0x8d, 0x22, 0x03,
                0xa9, 0x14,
                0x8d, 0x23, 0x03,
                0xa9, 0x19,
                0x8d, 0x24, 0x03,
                0xa9, 0x11,
                0x8d, 0x25, 0x03,

                0xa9, 0x23,
                0x8d, 0x26, 0x03,
                0xa9, 0x84,
                0x8d, 0x27, 0x03,
                0xa9, 0x08,
                0x8d, 0x28, 0x03,

                0x4c, 0x8b, 0xc2 // Then jump back to where we were before.
            };
            for (int lnI = 0; lnI < romPlugin.Length; lnI++)
                romData[0xa10 + lnI] = romPlugin[lnI];

            romPlugin = new byte[] { 0x4c, 0x00, 0x8a };
            for (int lnI = 0; lnI < romPlugin.Length; lnI++)
                romData[0x428f + lnI] = romPlugin[lnI];
        }

        private void changeLaps(Random r1)
        {
            // Enforce 1 lap for Challenge and 2 laps for Excitebike
            for (int lnI = 0; lnI < 8; lnI++)
            {
                if (cboChallengeLaps.SelectedIndex < 9)
                    romData[0x20 + lnI] = (byte)(cboChallengeLaps.SelectedIndex + 1);
                else if (cboChallengeLaps.SelectedIndex == 9)
                    romData[0x20 + lnI] = (byte)(1 + (r1.Next() % 9));
                else if (cboChallengeLaps.SelectedIndex == 10)
                    romData[0x20 + lnI] = (byte)(1 + (r1.Next() % 5));
                else if (cboChallengeLaps.SelectedIndex == 11)
                    romData[0x20 + lnI] = (byte)(5 + (r1.Next() % 5));
            }

            for (int lnI = 0; lnI < 8; lnI++)
            {
                if (cboExcitebikeLaps.SelectedIndex < 9)
                    romData[0x28 + lnI] = (byte)(cboExcitebikeLaps.SelectedIndex + 1);
                else if (cboExcitebikeLaps.SelectedIndex == 9)
                    romData[0x28 + lnI] = (byte)(1 + (r1.Next() % 9));
                else if (cboExcitebikeLaps.SelectedIndex == 10)
                    romData[0x28 + lnI] = (byte)(1 + (r1.Next() % 5));
                else if (cboExcitebikeLaps.SelectedIndex == 11)
                    romData[0x28 + lnI] = (byte)(5 + (r1.Next() % 5));
            }

            byte[] bytesToAdd = {
                0x48,
                0xa5, 0x46,
                0xd0, 0x09,
                0xa6, 0x43,
                0xbd, 0x10, 0x80,
                0x85, 0x57,
                0x68,
                0x60,
                0xa6, 0x43,
                0xbd, 0x18, 0x80,
                0x85, 0x57,
                0x68,
                0x60
            };

            for (int lnI = 0; lnI < bytesToAdd.Length; lnI++)
                romData[0x30 + lnI] = bytesToAdd[lnI];

            romData[0x752e] = 0x20;
            romData[0x752f] = 0x20;
            romData[0x7530] = 0x80;
            romData[0x7531] = 0xea;
        }

        private void createVSSetup()
        {
            // This will alternate races between Challenge and Excitebike.  So you always qualify before the actual race.
            byte[] bytesToAdd = {
                0x20, 0x80, 0x80, // JSR $8080 - The bike speed loading mechanism
                0xa5, 0x46, // LDA $46
                0xd0, 0x05, // BNE +5 bytes (if in Excitebike mode...)
                0xa9, 0x01, // LDA #01 - If in qualify mode, make it excitebike
                0x85, 0x46, // STA $46
                0x60, // RTS
                0xa9, 0x00, // Otherwise, make it qualify mode
                0x85, 0x46, // STA $46
                0xa9, 0x01, // LDA #01
                0x85, 0x4b, // STA $4B
                0x60 // RTS
            };

            for (int lnI = 0; lnI < bytesToAdd.Length; lnI++)
                romData[0x50 + lnI] = bytesToAdd[lnI];

            romData[0x4b7d] = 0x20; // JSR $8040
            romData[0x4b7e] = 0x40;
            romData[0x4b7f] = 0x80;
            romData[0x4b80] = 0xea; // NOP
        }

        private void alternateOpponents()
        {
            romData[0x48b6] = romData[0x49cc] = romData[0x4b1a] = romData[0x4b52] = 0x46;
            romData[0x48b7] = romData[0x49cd] = romData[0x4b1b] = romData[0x4b53] = 0x00;
        }

        private void expandRom()
        {
            byte[] romData2 = new byte[0xa010];
            for (int lnI = 0; lnI < 0x10; lnI++)
                romData2[lnI] = romData[lnI];
            for (int lnI = 0x10; lnI < romData.Length; lnI++)
                romData2[lnI + 0x4000] = romData[lnI];

            romData2[0x04] = 0x02; // Expand to 2 pages
            romData = romData2;
        }

        private void randomizeObstacles(Random r1)
        {
            // Change track pointers
            romData[0x7512] = 0x00;
            romData[0x7513] = 0x80;
            romData[0x7517] = 0x08;
            romData[0x7518] = 0x80;
            romData[0x10] = romData[0x11] = romData[0x12] = romData[0x13] = romData[0x14] = romData[0x15] = romData[0x16] = romData[0x17] = 0;
            romData[0x18] = 0x81;
            romData[0x19] = 0x82;
            romData[0x1a] = 0x83;
            romData[0x1b] = 0x84;
            romData[0x1c] = 0x85;
            romData[0x1d] = 0x86;
            romData[0x1e] = 0x87;
            romData[0x1f] = 0x88;

            int[] trackObstaclePointers = { 0x110, 0x210, 0x310, 0x410, 0x510, 0x610, 0x710, 0x810 };
            
            for (int lnI = 0; lnI < trackObstaclePointers.Length; lnI++)
            {
                //double speed = (((romData[0x75] * 256) + romData[0x70]) + ((romData[0x7f] * 256) + romData[0x7a])) / 2;
                double speed = Math.Max((romData[0x75 + lnI] * 256) + romData[0x70 + lnI], (romData[0x7f + lnI] * 256) + romData[0x7a + lnI]);
                int maxGap = (int)Math.Floor(64 * (speed / 840));

                romData[trackObstaclePointers[lnI]] = 0x02;
                romData[trackObstaclePointers[lnI] + 1] = 0x40;
                romData[trackObstaclePointers[lnI] + 2] = (byte)(16 + (r1.Next() % maxGap));
                romData[trackObstaclePointers[lnI] + 3] = 0x30;

                double record1 = 3.0 + (romData[trackObstaclePointers[lnI] + 2] * 0.03);
                double record2 = 3.0 + (romData[trackObstaclePointers[lnI] + 2] * 0.03);

                int obstPointer = trackObstaclePointers[lnI] + 4;
                int obstacleBytes = (lnI == 0 ? 120 : lnI == 1 ? 160 : lnI == 2 ? 200 : 236);
                while (obstacleBytes > 0)
                {
                    int ebObstacle = (r1.Next() % 4 == 0 ? 0x80 : 0x00);

                    romData[obstPointer] = 0x40;
                    if (r1.Next() % (lnI == 0 ? 2 : lnI == 1 ? 3 : lnI == 2 ? 4 : 5) != 0)
                        romData[obstPointer + 1] = (byte)(0x02 + (r1.Next() % 6));
                    else
                        romData[obstPointer + 1] = (byte)(0x02 + (r1.Next() % maxGap));

                    record1 += (romData[obstPointer + 1] * 0.03);
                    record2 += (romData[obstPointer + 1] * 0.03);

                    int obstacle = (r1.Next() % 20);
                    switch (obstacle)
                    {
                        case 0: // A
                            romData[obstPointer + 2] = (byte)(0x08 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .6;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.6);
                            break;
                        case 1: // B
                            romData[obstPointer + 2] = (byte)(0x07 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .6;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.6);
                            break;
                        case 2: // C
                            romData[obstPointer + 2] = (byte)(0x05 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .6;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.6);
                            break;
                        case 3: // D
                            romData[obstPointer + 2] = (byte)(0x01 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .6;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.6);
                            break;
                        case 4: // E
                            romData[obstPointer + 2] = (byte)(0x0b + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .6;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.6);
                            break;
                        case 5: // F
                            romData[obstPointer + 2] = (byte)(0x06 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .6;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.6);
                            break;
                        case 6: // G
                            romData[obstPointer + 2] = (byte)(0x0a + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .6;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.6);
                            break;
                        case 7: // H
                            romData[obstPointer + 2] = (byte)(0x0e + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += 0;
                            record1 += 0;
                            break;
                        case 8: // I
                            romData[obstPointer + 2] = (byte)(0x02 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .25;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.25);
                            break;
                        case 9: // J
                            romData[obstPointer + 2] = (byte)(0x04 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .25;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.25);
                            break;
                        case 10: // K
                            romData[obstPointer + 2] = (byte)(0x0c + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .25;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.25);
                            break;
                        case 11: // L
                            romData[obstPointer + 2] = (byte)(0x0d + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .25;
                            record1 += (ebObstacle == 0x80 ? 0 : 0.25);
                            break;
                        case 12: // M
                            romData[obstPointer + 2] = (byte)(0x0f + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += 0;
                            record1 += 0;
                            break;
                        case 13: // N
                            romData[obstPointer + 2] = (byte)(0x10 + ebObstacle);
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += 0;
                            record1 += 0;
                            break;
                        case 14: // O
                            romData[obstPointer + 2] = 0x12;
                            romData[obstPointer + 3] = 0x42;
                            romData[obstPointer + 4] = (byte)(4 + (r1.Next() % 30));
                            romData[obstPointer + 5] = 0x19;

                            record2 += .04 * (romData[obstPointer + 4]);
                            record1 += .04 * (romData[obstPointer + 4]);

                            obstPointer += 6;
                            obstacleBytes -= 6;

                            break;
                        case 15: // P
                            romData[obstPointer + 2] = 0x13;
                            romData[obstPointer + 3] = 0x43;
                            romData[obstPointer + 4] = (byte)(4 + (r1.Next() % 30));
                            romData[obstPointer + 5] = 0x1b;

                            record2 += .04 * (romData[obstPointer + 4]);
                            record1 += .04 * (romData[obstPointer + 4]);

                            obstPointer += 6;
                            obstacleBytes -= 6;

                            break;
                        case 16: // Q
                            romData[obstPointer + 2] = 0x11;
                            romData[obstPointer + 3] = 0x46;
                            romData[obstPointer + 4] = (byte)(4 + (r1.Next() % 20));
                            romData[obstPointer + 5] = 0x17;

                            record2 += .1 * (romData[obstPointer + 4]);
                            record1 += .1 * (romData[obstPointer + 4]);

                            obstPointer += 6;
                            obstacleBytes -= 6;

                            break;
                        case 17: // R
                            byte distance1 = (byte)(0x02 + ((speed / 280) * (speed / 280)) + (r1.Next() % 7));
                            byte distance2 = (byte)(0x02 + ((speed / 280) * (speed / 280)) + (r1.Next() % 7));
                            romData[obstPointer + 2] = 0x15;
                            romData[obstPointer + 3] = 0x41;
                            romData[obstPointer + 4] = distance1;
                            romData[obstPointer + 5] = 0x21;
                            romData[obstPointer + 6] = 0x45;
                            romData[obstPointer + 7] = distance2;
                            romData[obstPointer + 8] = 0x23;
                            obstPointer += 9;
                            obstacleBytes -= 9;

                            record2 += 2.2 + (.04 * (distance1 + distance2));
                            record1 += 2.2 + (.04 * (distance1 + distance2));
                            break;
                        case 18: // S
                            byte distance4 = (byte)(0x02 + ((speed / 280) * (speed / 280)) + (r1.Next() % 7));
                            byte distance5 = (byte)(0x02 + ((speed / 280) * (speed / 280)) + (r1.Next() % 7));
                            byte distance6 = (byte)(0x02 + ((speed / 280) * (speed / 280)) + (r1.Next() % 7));
                            romData[obstPointer + 2] = 0x14;
                            romData[obstPointer + 3] = 0x44;
                            romData[obstPointer + 4] = distance4;
                            romData[obstPointer + 5] = 0x1e;
                            romData[obstPointer + 6] = 0x44;
                            romData[obstPointer + 7] = distance5;
                            romData[obstPointer + 8] = 0x1e;
                            romData[obstPointer + 9] = 0x44;
                            romData[obstPointer + 10] = distance6;
                            romData[obstPointer + 11] = 0x1f;
                            romData[obstPointer + 12] = 0x1b;
                            obstPointer += 13;
                            obstacleBytes -= 13;

                            record2 += 1.5 + (.04 * (distance4 + distance5 + distance6));
                            record1 += 1.5 + (.04 * (distance4 + distance5 + distance6));
                            break;
                        case 19: // No obstacle
                            romData[obstPointer + 2] = 0x31;
                            obstPointer += 3;
                            obstacleBytes -= 3;

                            record2 += .03;
                            record1 += .03;
                            break;
                    }
                }

                romData[obstPointer] = 0x40;
                romData[obstPointer + 1] = (byte)(4 + (r1.Next() % 30));
                romData[obstPointer + 2] = 0x09;

                if (lnI < 5)
                {
                    record1 *= (romData[0x20 + lnI] * 1.25);
                    record2 *= (romData[0x28 + lnI] * (chkVSOpponents.Checked ? 1.35 : 1.25));

                    record1 *= 840 / speed;
                    record2 *= 840 / speed;

                    if (record1 > 540) record1 = 540;
                    if (record2 > 540) record2 = 540;

                    romData[0x40a1 + (lnI * 3) + 0] = (byte)(Math.Floor(record1 / 60));
                    romData[0x40a1 + (lnI * 3) + 1] = (byte)(Math.Floor(record1 % 60));
                    romData[0x40a1 + (lnI * 3) + 2] = (byte)(0);

                    romData[0x40b1 + (lnI * 3) + 0] = (byte)(Math.Floor(record2 / 60));
                    romData[0x40b1 + (lnI * 3) + 1] = (byte)(Math.Floor(record2 % 60));
                    romData[0x40b1 + (lnI * 3) + 2] = (byte)(0);
                }

            }
        }

        private void randomizeBikeSpeed(Random r1)
        {
            for (int lnI = 0; lnI < 5; lnI++)
            {
                int byteToUse = 0x70 + lnI;

                int bikeSpeed1 = 800;
                int bikeSpeed2 = 832;

                switch (cboBikeSpeed.SelectedIndex)
                {
                    case 0:
                        bikeSpeed1 = 400;
                        bikeSpeed2 = 416;
                        break;
                    case 1:
                        bikeSpeed1 = 600;
                        bikeSpeed2 = 624;
                        break;
                    case 2:
                        bikeSpeed1 = 800;
                        bikeSpeed2 = 832;
                        break;
                    case 3:
                        bikeSpeed1 = 1200;
                        bikeSpeed2 = 1248;
                        break;
                    case 4:
                        bikeSpeed1 = 1600;
                        bikeSpeed2 = 1664;
                        break;
                    case 5:
                        bikeSpeed1 = ScaleValue(800, 2.0, 1.0, r1);
                        bikeSpeed2 = ScaleValue(832, 2.0, 1.0, r1);
                        break;
                    case 6:
                        bikeSpeed1 = 200 + ScaleValue(400, 2.0, 1.0, r1);
                        bikeSpeed2 = 208 + ScaleValue(416, 2.0, 1.0, r1);
                        break;
                    case 7:
                        bikeSpeed1 = 800 + ScaleValue(400, 2.0, 1.0, r1);
                        bikeSpeed2 = 832 + ScaleValue(416, 2.0, 1.0, r1);
                        break;

                }

                // If turbo is slower than regular, there's a 75% chance to put it "back to normal".
                if (bikeSpeed1 > bikeSpeed2 && r1.Next() % 4 >= 1)
                {
                    int hold = bikeSpeed1;
                    bikeSpeed1 = bikeSpeed2;
                    bikeSpeed2 = hold;
                }

                romData[byteToUse + 0] = (byte)(bikeSpeed1 % 256);
                romData[byteToUse + 5] = (byte)(bikeSpeed1 / 256);

                // Turbo acceleration
                romData[byteToUse + 10] = (byte)(bikeSpeed2 % 256);
                romData[byteToUse + 15] = (byte)(bikeSpeed2 / 256);
            }

            // Change max bike speed pointers to ones stored in RAM:  $0600 and $0602
            romData[0x4db6] = romData[0x4e59] = romData[0x4e5e] = 0x00; // 0x60;
            romData[0x4db7] = romData[0x4e5a] = romData[0x4e5f] = 0x06; // 0x80;
            romData[0x4dad] = romData[0x4e4f] = romData[0x4e63] = 0x02; // 0x62;
            romData[0x4dae] = romData[0x4e50] = romData[0x4e64] = 0x06; // 0x80;

            // Get bike speeds based on track number
            byte[] bytesToAdd =
            {
                0xa6, 0x43, // LDX $43
                0xbd, 0x60, 0x80, // LDA $8060, X
                0x8d, 0x00, 0x06, // STA $0600
                0xbd, 0x65, 0x80, // LDA $8065, X
                0x8d, 0x02, 0x06, // STA $0602
                0xbd, 0x6a, 0x80, // LDA $806A, X
                0x8d, 0x01, 0x06, // STA $0601
                0xbd, 0x6f, 0x80, // LDA $806F, X
                0x8d, 0x03, 0x06, // STA $0603
                0x60 // RTS
            };

            for (int lnI = 0; lnI < bytesToAdd.Length; lnI++)
                romData[0x90 + lnI] = bytesToAdd[lnI];

            bytesToAdd = new byte[]
            {
                0xa5, 0x42, // LDA $42
                0x85, 0x43, // STA $43
                0x20, 0x80, 0x80, // JSR $8080
                0x60 // RTS
            };
            for (int lnI = 0; lnI < bytesToAdd.Length; lnI++)
                romData[0xb0 + lnI] = bytesToAdd[lnI];

            romData[0x43bb] = 0x20;
            romData[0x43bc] = 0xa0;
            romData[0x43bd] = 0x80;
            romData[0x43be] = 0xea;
        }

        private int ScaleValue(int value, double scale, double adjustment, Random r1)
        {
            var exponent = (double)r1.Next() / int.MaxValue * 2.0 - 1.0;
            var adjustedScale = 1.0 + adjustment * (scale - 1.0);

            return (int)Math.Round(Math.Pow(adjustedScale, exponent) * value, MidpointRounding.AwayFromZero);
        }

        private void randomizeColors(Random r1)
        {
            int[] trackColorPointers = { 0x53e6, 0x53f9, 0x540c, 0x541f, 0x5432 };

            for (int lnI = 0; lnI < trackColorPointers.Length; lnI++)
            {
                for (int lnJ = 3; lnJ < 19; lnJ++)
                    romData[trackColorPointers[lnI] + lnJ] = (byte)(r1.Next() % 64);
            }
        }

        private int inverted_power_curve(int min, int max, double powToUse, Random r1)
        {
            int range = max - min;
            double p_range = Math.Pow(range, 1 / powToUse);
            double section = (double)r1.Next() / int.MaxValue;
            int points = (int)Math.Round(max - Math.Pow(section * p_range, powToUse));
            return points;
        }

        private void speedHacks()
        {
            romData[0x0919] = romData[0x3f2f] = romData[0x3f22] = 0x01;
        }
    }
}
