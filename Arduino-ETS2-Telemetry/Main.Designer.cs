namespace SCSTelemetryServer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.screenButton = new System.Windows.Forms.Button();
            this.screenText = new System.Windows.Forms.TextBox();
            this.jsonTest = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gameVersion = new System.Windows.Forms.TextBox();
            this.gamePaused = new System.Windows.Forms.TextBox();
            this.truckLocation = new System.Windows.Forms.TextBox();
            this.truckRadioSignal = new System.Windows.Forms.TextBox();
            this.truckRadioStation = new System.Windows.Forms.TextBox();
            this.truckCountry = new System.Windows.Forms.TextBox();
            this.truckCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gameTime = new System.Windows.Forms.TextBox();
            this.gameDay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbGeneral = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.truckRetarderLevel = new System.Windows.Forms.TextBox();
            this.truckBrakeTemperature = new System.Windows.Forms.TextBox();
            this.truckAirPressure = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.truckWaterTempWarn = new System.Windows.Forms.TextBox();
            this.truckOilPressureWarn = new System.Windows.Forms.TextBox();
            this.truckFuelWarn = new System.Windows.Forms.TextBox();
            this.truckAirPressureEmerWarn = new System.Windows.Forms.TextBox();
            this.truckBatteryVoltageWarn = new System.Windows.Forms.TextBox();
            this.truckAdblueWarn = new System.Windows.Forms.TextBox();
            this.truckAirPressureWarn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.truckFuelRange = new System.Windows.Forms.TextBox();
            this.truckCruiseControl = new System.Windows.Forms.TextBox();
            this.truckGear = new System.Windows.Forms.TextBox();
            this.truckFuel = new System.Windows.Forms.TextBox();
            this.truckCruiseControlSpeed = new System.Windows.Forms.TextBox();
            this.truckSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.truckTransmission = new System.Windows.Forms.TextBox();
            this.truckFuelCap = new System.Windows.Forms.TextBox();
            this.truckMileage = new System.Windows.Forms.TextBox();
            this.truckModel = new System.Windows.Forms.TextBox();
            this.truckManufacture = new System.Windows.Forms.TextBox();
            this.truckRegPlate = new System.Windows.Forms.TextBox();
            this.truckInfoLabel = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 396);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Controls.Add(this.screenButton);
            this.tabPage3.Controls.Add(this.screenText);
            this.tabPage3.Controls.Add(this.jsonTest);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Server Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // screenButton
            // 
            this.screenButton.Location = new System.Drawing.Point(112, 241);
            this.screenButton.Name = "screenButton";
            this.screenButton.Size = new System.Drawing.Size(75, 23);
            this.screenButton.TabIndex = 2;
            this.screenButton.Text = "Set Screen";
            this.screenButton.UseVisualStyleBackColor = true;
            this.screenButton.Click += new System.EventHandler(this.screenButton_Click);
            // 
            // screenText
            // 
            this.screenText.Location = new System.Drawing.Point(6, 243);
            this.screenText.Name = "screenText";
            this.screenText.Size = new System.Drawing.Size(100, 20);
            this.screenText.TabIndex = 1;
            // 
            // jsonTest
            // 
            this.jsonTest.Location = new System.Drawing.Point(6, 6);
            this.jsonTest.Name = "jsonTest";
            this.jsonTest.Size = new System.Drawing.Size(756, 231);
            this.jsonTest.TabIndex = 0;
            this.jsonTest.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gameVersion);
            this.tabPage1.Controls.Add(this.gamePaused);
            this.tabPage1.Controls.Add(this.truckLocation);
            this.tabPage1.Controls.Add(this.truckRadioSignal);
            this.tabPage1.Controls.Add(this.truckRadioStation);
            this.tabPage1.Controls.Add(this.truckCountry);
            this.tabPage1.Controls.Add(this.truckCity);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.gameTime);
            this.tabPage1.Controls.Add(this.gameDay);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lbGeneral);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gameVersion
            // 
            this.gameVersion.Location = new System.Drawing.Point(250, 53);
            this.gameVersion.Name = "gameVersion";
            this.gameVersion.Size = new System.Drawing.Size(180, 20);
            this.gameVersion.TabIndex = 45;
            this.gameVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gamePaused
            // 
            this.gamePaused.Location = new System.Drawing.Point(64, 53);
            this.gamePaused.Name = "gamePaused";
            this.gamePaused.Size = new System.Drawing.Size(180, 20);
            this.gamePaused.TabIndex = 44;
            this.gamePaused.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckLocation
            // 
            this.truckLocation.Location = new System.Drawing.Point(64, 210);
            this.truckLocation.Name = "truckLocation";
            this.truckLocation.Size = new System.Drawing.Size(366, 20);
            this.truckLocation.TabIndex = 43;
            this.truckLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckRadioSignal
            // 
            this.truckRadioSignal.Location = new System.Drawing.Point(250, 184);
            this.truckRadioSignal.Name = "truckRadioSignal";
            this.truckRadioSignal.Size = new System.Drawing.Size(180, 20);
            this.truckRadioSignal.TabIndex = 42;
            this.truckRadioSignal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckRadioStation
            // 
            this.truckRadioStation.Location = new System.Drawing.Point(64, 184);
            this.truckRadioStation.Name = "truckRadioStation";
            this.truckRadioStation.Size = new System.Drawing.Size(180, 20);
            this.truckRadioStation.TabIndex = 41;
            this.truckRadioStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckCountry
            // 
            this.truckCountry.Location = new System.Drawing.Point(250, 158);
            this.truckCountry.Name = "truckCountry";
            this.truckCountry.Size = new System.Drawing.Size(180, 20);
            this.truckCountry.TabIndex = 40;
            this.truckCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckCity
            // 
            this.truckCity.Location = new System.Drawing.Point(64, 158);
            this.truckCity.Name = "truckCity";
            this.truckCity.Size = new System.Drawing.Size(180, 20);
            this.truckCity.TabIndex = 39;
            this.truckCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Geographic Information";
            // 
            // gameTime
            // 
            this.gameTime.Location = new System.Drawing.Point(250, 27);
            this.gameTime.Name = "gameTime";
            this.gameTime.Size = new System.Drawing.Size(180, 20);
            this.gameTime.TabIndex = 13;
            this.gameTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gameDay
            // 
            this.gameDay.Location = new System.Drawing.Point(64, 27);
            this.gameDay.Name = "gameDay";
            this.gameDay.Size = new System.Drawing.Size(180, 20);
            this.gameDay.TabIndex = 12;
            this.gameDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(153, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Current Game Information";
            // 
            // lbGeneral
            // 
            this.lbGeneral.Location = new System.Drawing.Point(510, 0);
            this.lbGeneral.Name = "lbGeneral";
            this.lbGeneral.Size = new System.Drawing.Size(258, 374);
            this.lbGeneral.TabIndex = 1;
            this.lbGeneral.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.truckRetarderLevel);
            this.tabPage2.Controls.Add(this.truckBrakeTemperature);
            this.tabPage2.Controls.Add(this.truckAirPressure);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.truckWaterTempWarn);
            this.tabPage2.Controls.Add(this.truckOilPressureWarn);
            this.tabPage2.Controls.Add(this.truckFuelWarn);
            this.tabPage2.Controls.Add(this.truckAirPressureEmerWarn);
            this.tabPage2.Controls.Add(this.truckBatteryVoltageWarn);
            this.tabPage2.Controls.Add(this.truckAdblueWarn);
            this.tabPage2.Controls.Add(this.truckAirPressureWarn);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.truckFuelRange);
            this.tabPage2.Controls.Add(this.truckCruiseControl);
            this.tabPage2.Controls.Add(this.truckGear);
            this.tabPage2.Controls.Add(this.truckFuel);
            this.tabPage2.Controls.Add(this.truckCruiseControlSpeed);
            this.tabPage2.Controls.Add(this.truckSpeed);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.truckTransmission);
            this.tabPage2.Controls.Add(this.truckFuelCap);
            this.tabPage2.Controls.Add(this.truckMileage);
            this.tabPage2.Controls.Add(this.truckModel);
            this.tabPage2.Controls.Add(this.truckManufacture);
            this.tabPage2.Controls.Add(this.truckRegPlate);
            this.tabPage2.Controls.Add(this.truckInfoLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Truck Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // truckRetarderLevel
            // 
            this.truckRetarderLevel.Location = new System.Drawing.Point(381, 203);
            this.truckRetarderLevel.Name = "truckRetarderLevel";
            this.truckRetarderLevel.Size = new System.Drawing.Size(180, 20);
            this.truckRetarderLevel.TabIndex = 35;
            this.truckRetarderLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckBrakeTemperature
            // 
            this.truckBrakeTemperature.Location = new System.Drawing.Point(381, 177);
            this.truckBrakeTemperature.Name = "truckBrakeTemperature";
            this.truckBrakeTemperature.Size = new System.Drawing.Size(180, 20);
            this.truckBrakeTemperature.TabIndex = 34;
            this.truckBrakeTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckAirPressure
            // 
            this.truckAirPressure.Location = new System.Drawing.Point(381, 151);
            this.truckAirPressure.Name = "truckAirPressure";
            this.truckAirPressure.Size = new System.Drawing.Size(180, 20);
            this.truckAirPressure.TabIndex = 33;
            this.truckAirPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(195, 342);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 20);
            this.textBox1.TabIndex = 32;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckWaterTempWarn
            // 
            this.truckWaterTempWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckWaterTempWarn.Location = new System.Drawing.Point(9, 342);
            this.truckWaterTempWarn.Name = "truckWaterTempWarn";
            this.truckWaterTempWarn.Size = new System.Drawing.Size(180, 20);
            this.truckWaterTempWarn.TabIndex = 31;
            this.truckWaterTempWarn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckOilPressureWarn
            // 
            this.truckOilPressureWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckOilPressureWarn.Location = new System.Drawing.Point(195, 316);
            this.truckOilPressureWarn.Name = "truckOilPressureWarn";
            this.truckOilPressureWarn.Size = new System.Drawing.Size(180, 20);
            this.truckOilPressureWarn.TabIndex = 30;
            this.truckOilPressureWarn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckFuelWarn
            // 
            this.truckFuelWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckFuelWarn.Location = new System.Drawing.Point(195, 290);
            this.truckFuelWarn.Name = "truckFuelWarn";
            this.truckFuelWarn.Size = new System.Drawing.Size(180, 20);
            this.truckFuelWarn.TabIndex = 29;
            this.truckFuelWarn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckAirPressureEmerWarn
            // 
            this.truckAirPressureEmerWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckAirPressureEmerWarn.Location = new System.Drawing.Point(195, 264);
            this.truckAirPressureEmerWarn.Name = "truckAirPressureEmerWarn";
            this.truckAirPressureEmerWarn.Size = new System.Drawing.Size(180, 20);
            this.truckAirPressureEmerWarn.TabIndex = 28;
            this.truckAirPressureEmerWarn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckBatteryVoltageWarn
            // 
            this.truckBatteryVoltageWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckBatteryVoltageWarn.Location = new System.Drawing.Point(9, 316);
            this.truckBatteryVoltageWarn.Name = "truckBatteryVoltageWarn";
            this.truckBatteryVoltageWarn.Size = new System.Drawing.Size(180, 20);
            this.truckBatteryVoltageWarn.TabIndex = 27;
            this.truckBatteryVoltageWarn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckAdblueWarn
            // 
            this.truckAdblueWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckAdblueWarn.Location = new System.Drawing.Point(9, 290);
            this.truckAdblueWarn.Name = "truckAdblueWarn";
            this.truckAdblueWarn.Size = new System.Drawing.Size(180, 20);
            this.truckAdblueWarn.TabIndex = 26;
            this.truckAdblueWarn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckAirPressureWarn
            // 
            this.truckAirPressureWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckAirPressureWarn.Location = new System.Drawing.Point(9, 264);
            this.truckAirPressureWarn.Name = "truckAirPressureWarn";
            this.truckAirPressureWarn.Size = new System.Drawing.Size(180, 20);
            this.truckAirPressureWarn.TabIndex = 25;
            this.truckAirPressureWarn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Truck Warnings";
            // 
            // truckFuelRange
            // 
            this.truckFuelRange.Location = new System.Drawing.Point(195, 203);
            this.truckFuelRange.Name = "truckFuelRange";
            this.truckFuelRange.Size = new System.Drawing.Size(180, 20);
            this.truckFuelRange.TabIndex = 19;
            this.truckFuelRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckCruiseControl
            // 
            this.truckCruiseControl.Location = new System.Drawing.Point(195, 177);
            this.truckCruiseControl.Name = "truckCruiseControl";
            this.truckCruiseControl.Size = new System.Drawing.Size(180, 20);
            this.truckCruiseControl.TabIndex = 18;
            this.truckCruiseControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckGear
            // 
            this.truckGear.Location = new System.Drawing.Point(195, 151);
            this.truckGear.Name = "truckGear";
            this.truckGear.Size = new System.Drawing.Size(180, 20);
            this.truckGear.TabIndex = 17;
            this.truckGear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckFuel
            // 
            this.truckFuel.Location = new System.Drawing.Point(9, 203);
            this.truckFuel.Name = "truckFuel";
            this.truckFuel.Size = new System.Drawing.Size(180, 20);
            this.truckFuel.TabIndex = 16;
            this.truckFuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckCruiseControlSpeed
            // 
            this.truckCruiseControlSpeed.Location = new System.Drawing.Point(9, 177);
            this.truckCruiseControlSpeed.Name = "truckCruiseControlSpeed";
            this.truckCruiseControlSpeed.Size = new System.Drawing.Size(180, 20);
            this.truckCruiseControlSpeed.TabIndex = 15;
            this.truckCruiseControlSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckSpeed
            // 
            this.truckSpeed.Location = new System.Drawing.Point(9, 151);
            this.truckSpeed.Name = "truckSpeed";
            this.truckSpeed.Size = new System.Drawing.Size(180, 20);
            this.truckSpeed.TabIndex = 14;
            this.truckSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Driving Telemetry";
            // 
            // truckTransmission
            // 
            this.truckTransmission.Location = new System.Drawing.Point(192, 87);
            this.truckTransmission.Name = "truckTransmission";
            this.truckTransmission.Size = new System.Drawing.Size(180, 20);
            this.truckTransmission.TabIndex = 12;
            this.truckTransmission.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckFuelCap
            // 
            this.truckFuelCap.Location = new System.Drawing.Point(192, 61);
            this.truckFuelCap.Name = "truckFuelCap";
            this.truckFuelCap.Size = new System.Drawing.Size(180, 20);
            this.truckFuelCap.TabIndex = 11;
            this.truckFuelCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckMileage
            // 
            this.truckMileage.Location = new System.Drawing.Point(192, 35);
            this.truckMileage.Name = "truckMileage";
            this.truckMileage.Size = new System.Drawing.Size(180, 20);
            this.truckMileage.TabIndex = 10;
            this.truckMileage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckModel
            // 
            this.truckModel.Location = new System.Drawing.Point(6, 87);
            this.truckModel.Name = "truckModel";
            this.truckModel.Size = new System.Drawing.Size(180, 20);
            this.truckModel.TabIndex = 9;
            this.truckModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckManufacture
            // 
            this.truckManufacture.Location = new System.Drawing.Point(6, 61);
            this.truckManufacture.Name = "truckManufacture";
            this.truckManufacture.Size = new System.Drawing.Size(180, 20);
            this.truckManufacture.TabIndex = 8;
            this.truckManufacture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckRegPlate
            // 
            this.truckRegPlate.Location = new System.Drawing.Point(6, 35);
            this.truckRegPlate.Name = "truckRegPlate";
            this.truckRegPlate.Size = new System.Drawing.Size(180, 20);
            this.truckRegPlate.TabIndex = 7;
            this.truckRegPlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // truckInfoLabel
            // 
            this.truckInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.truckInfoLabel.AutoSize = true;
            this.truckInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truckInfoLabel.Location = new System.Drawing.Point(125, 11);
            this.truckInfoLabel.Name = "truckInfoLabel";
            this.truckInfoLabel.Size = new System.Drawing.Size(133, 20);
            this.truckInfoLabel.TabIndex = 3;
            this.truckInfoLabel.Text = "Truck Information";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 370);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Trailer Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(768, 370);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Job Data";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(768, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arduino-ETS2 Telemetry Server";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(381, 269);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 17);
            this.listBox1.TabIndex = 3;
            // 
            // Main
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Arduino-ETS2-Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArduinoETS2Telemetry_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox lbGeneral;
        private System.Windows.Forms.Label truckInfoLabel;
        private System.Windows.Forms.TextBox truckRegPlate;
        private System.Windows.Forms.TextBox truckTransmission;
        private System.Windows.Forms.TextBox truckFuelCap;
        private System.Windows.Forms.TextBox truckMileage;
        private System.Windows.Forms.TextBox truckModel;
        private System.Windows.Forms.TextBox truckManufacture;
        private System.Windows.Forms.TextBox truckFuelRange;
        private System.Windows.Forms.TextBox truckCruiseControl;
        private System.Windows.Forms.TextBox truckGear;
        private System.Windows.Forms.TextBox truckFuel;
        private System.Windows.Forms.TextBox truckCruiseControlSpeed;
        private System.Windows.Forms.TextBox truckSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox truckWaterTempWarn;
        private System.Windows.Forms.TextBox truckOilPressureWarn;
        private System.Windows.Forms.TextBox truckFuelWarn;
        private System.Windows.Forms.TextBox truckAirPressureEmerWarn;
        private System.Windows.Forms.TextBox truckBatteryVoltageWarn;
        private System.Windows.Forms.TextBox truckAdblueWarn;
        private System.Windows.Forms.TextBox truckAirPressureWarn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox gameTime;
        private System.Windows.Forms.TextBox gameDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox truckRadioSignal;
        private System.Windows.Forms.TextBox truckRadioStation;
        private System.Windows.Forms.TextBox truckCountry;
        private System.Windows.Forms.TextBox truckCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox truckLocation;
        private System.Windows.Forms.TextBox gameVersion;
        private System.Windows.Forms.TextBox gamePaused;
        private System.Windows.Forms.RichTextBox jsonTest;
        private System.Windows.Forms.TextBox truckRetarderLevel;
        private System.Windows.Forms.TextBox truckBrakeTemperature;
        private System.Windows.Forms.TextBox truckAirPressure;
        private System.Windows.Forms.TextBox screenText;
        private System.Windows.Forms.Button screenButton;
        private System.Windows.Forms.ListBox listBox1;
    }
}

