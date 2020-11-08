namespace RulesEditor {
    partial class RuleCreatorForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.actionOpenLabel1 = new System.Windows.Forms.Label();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.nameNeededLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.fromNeededLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.formWhereLabel = new System.Windows.Forms.Label();
            this.fromWhereTextBox = new System.Windows.Forms.TextBox();
            this.inNeededLabel = new System.Windows.Forms.Label();
            this.inLabel = new System.Windows.Forms.Label();
            this.inTextBox = new System.Windows.Forms.TextBox();
            this.whereLabel = new System.Windows.Forms.Label();
            this.whereTextBox = new System.Windows.Forms.TextBox();
            this.toNeededLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.toWhereLabel = new System.Windows.Forms.Label();
            this.toWhereTextBox = new System.Windows.Forms.TextBox();
            this.beforeLabel = new System.Windows.Forms.Label();
            this.beforeTextBox = new System.Windows.Forms.TextBox();
            this.afterLabel = new System.Windows.Forms.Label();
            this.afterTextBox = new System.Windows.Forms.TextBox();
            this.ifLabel = new System.Windows.Forms.Label();
            this.ifTextBox = new System.Windows.Forms.TextBox();
            this.currentNeededLabel = new System.Windows.Forms.Label();
            this.currentLabel = new System.Windows.Forms.Label();
            this.currentTextBox = new System.Windows.Forms.TextBox();
            this.valueNeededLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.actionOpenLabel2 = new System.Windows.Forms.Label();
            this.actionCloseLabel1 = new System.Windows.Forms.Label();
            this.actionTextBox = new System.Windows.Forms.TextBox();
            this.actionCloseLabel2 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // actionOpenLabel1
            // 
            this.actionOpenLabel1.AutoSize = true;
            this.actionOpenLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionOpenLabel1.Location = new System.Drawing.Point(8, 19);
            this.actionOpenLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.actionOpenLabel1.Name = "actionOpenLabel1";
            this.actionOpenLabel1.Size = new System.Drawing.Size(24, 25);
            this.actionOpenLabel1.TabIndex = 0;
            this.actionOpenLabel1.Text = "<";
            // 
            // actionComboBox
            // 
            this.actionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Items.AddRange(new object[] {
            "add",
            "change",
            "copy",
            "delete",
            "move",
            "path",
            "rename"});
            this.actionComboBox.Location = new System.Drawing.Point(39, 19);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(120, 28);
            this.actionComboBox.TabIndex = 1;
            this.actionComboBox.TextChanged += new System.EventHandler(this.RuleActionChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(80, 73);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(49, 25);
            this.typeLabel.TabIndex = 2;
            this.typeLabel.Text = "type";
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeComboBox.Enabled = false;
            this.typeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "element",
            "attribute",
            "namespace"});
            this.typeComboBox.Location = new System.Drawing.Point(206, 74);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(266, 28);
            this.typeComboBox.TabIndex = 2;
            this.typeComboBox.TextChanged += new System.EventHandler(this.RuleTypeChanged);
            // 
            // nameNeededLabel
            // 
            this.nameNeededLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameNeededLabel.AutoSize = true;
            this.nameNeededLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameNeededLabel.ForeColor = System.Drawing.Color.Red;
            this.nameNeededLabel.Location = new System.Drawing.Point(182, 115);
            this.nameNeededLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nameNeededLabel.Name = "nameNeededLabel";
            this.nameNeededLabel.Size = new System.Drawing.Size(20, 25);
            this.nameNeededLabel.TabIndex = 3;
            this.nameNeededLabel.Text = "*";
            this.nameNeededLabel.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(80, 113);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(61, 25);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nameTextBox.Location = new System.Drawing.Point(206, 114);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(266, 26);
            this.nameTextBox.TabIndex = 3;
            // 
            // fromNeededLabel
            // 
            this.fromNeededLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fromNeededLabel.AutoSize = true;
            this.fromNeededLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromNeededLabel.ForeColor = System.Drawing.Color.Red;
            this.fromNeededLabel.Location = new System.Drawing.Point(182, 156);
            this.fromNeededLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.fromNeededLabel.Name = "fromNeededLabel";
            this.fromNeededLabel.Size = new System.Drawing.Size(20, 25);
            this.fromNeededLabel.TabIndex = 5;
            this.fromNeededLabel.Text = "*";
            this.fromNeededLabel.Visible = false;
            // 
            // fromLabel
            // 
            this.fromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(80, 153);
            this.fromLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(50, 25);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "from";
            // 
            // fromTextBox
            // 
            this.fromTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fromTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fromTextBox.Location = new System.Drawing.Point(206, 154);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.ReadOnly = true;
            this.fromTextBox.Size = new System.Drawing.Size(266, 26);
            this.fromTextBox.TabIndex = 4;
            // 
            // formWhereLabel
            // 
            this.formWhereLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.formWhereLabel.AutoSize = true;
            this.formWhereLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formWhereLabel.Location = new System.Drawing.Point(80, 196);
            this.formWhereLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.formWhereLabel.Name = "formWhereLabel";
            this.formWhereLabel.Size = new System.Drawing.Size(109, 25);
            this.formWhereLabel.TabIndex = 7;
            this.formWhereLabel.Text = "fromWhere";
            // 
            // fromWhereTextBox
            // 
            this.fromWhereTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fromWhereTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fromWhereTextBox.Location = new System.Drawing.Point(206, 194);
            this.fromWhereTextBox.Name = "fromWhereTextBox";
            this.fromWhereTextBox.ReadOnly = true;
            this.fromWhereTextBox.Size = new System.Drawing.Size(266, 26);
            this.fromWhereTextBox.TabIndex = 5;
            // 
            // inNeededLabel
            // 
            this.inNeededLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.inNeededLabel.AutoSize = true;
            this.inNeededLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNeededLabel.ForeColor = System.Drawing.Color.Red;
            this.inNeededLabel.Location = new System.Drawing.Point(182, 236);
            this.inNeededLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.inNeededLabel.Name = "inNeededLabel";
            this.inNeededLabel.Size = new System.Drawing.Size(20, 25);
            this.inNeededLabel.TabIndex = 8;
            this.inNeededLabel.Text = "*";
            this.inNeededLabel.Visible = false;
            // 
            // inLabel
            // 
            this.inLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.inLabel.AutoSize = true;
            this.inLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inLabel.Location = new System.Drawing.Point(80, 233);
            this.inLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.inLabel.Name = "inLabel";
            this.inLabel.Size = new System.Drawing.Size(27, 25);
            this.inLabel.TabIndex = 9;
            this.inLabel.Text = "in";
            // 
            // inTextBox
            // 
            this.inTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inTextBox.Location = new System.Drawing.Point(206, 234);
            this.inTextBox.Name = "inTextBox";
            this.inTextBox.ReadOnly = true;
            this.inTextBox.Size = new System.Drawing.Size(266, 26);
            this.inTextBox.TabIndex = 6;
            // 
            // whereLabel
            // 
            this.whereLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.whereLabel.AutoSize = true;
            this.whereLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whereLabel.Location = new System.Drawing.Point(80, 277);
            this.whereLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.whereLabel.Name = "whereLabel";
            this.whereLabel.Size = new System.Drawing.Size(65, 25);
            this.whereLabel.TabIndex = 10;
            this.whereLabel.Text = "where";
            // 
            // whereTextBox
            // 
            this.whereTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whereTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.whereTextBox.Location = new System.Drawing.Point(206, 274);
            this.whereTextBox.Name = "whereTextBox";
            this.whereTextBox.ReadOnly = true;
            this.whereTextBox.Size = new System.Drawing.Size(266, 26);
            this.whereTextBox.TabIndex = 7;
            // 
            // toNeededLabel
            // 
            this.toNeededLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.toNeededLabel.AutoSize = true;
            this.toNeededLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toNeededLabel.ForeColor = System.Drawing.Color.Red;
            this.toNeededLabel.Location = new System.Drawing.Point(182, 316);
            this.toNeededLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toNeededLabel.Name = "toNeededLabel";
            this.toNeededLabel.Size = new System.Drawing.Size(20, 25);
            this.toNeededLabel.TabIndex = 11;
            this.toNeededLabel.Text = "*";
            this.toNeededLabel.Visible = false;
            // 
            // toLabel
            // 
            this.toLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(80, 313);
            this.toLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(28, 25);
            this.toLabel.TabIndex = 12;
            this.toLabel.Text = "to";
            // 
            // toTextBox
            // 
            this.toTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.toTextBox.Location = new System.Drawing.Point(206, 314);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.ReadOnly = true;
            this.toTextBox.Size = new System.Drawing.Size(266, 26);
            this.toTextBox.TabIndex = 8;
            // 
            // toWhereLabel
            // 
            this.toWhereLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.toWhereLabel.AutoSize = true;
            this.toWhereLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toWhereLabel.Location = new System.Drawing.Point(80, 353);
            this.toWhereLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toWhereLabel.Name = "toWhereLabel";
            this.toWhereLabel.Size = new System.Drawing.Size(87, 25);
            this.toWhereLabel.TabIndex = 13;
            this.toWhereLabel.Text = "toWhere";
            // 
            // toWhereTextBox
            // 
            this.toWhereTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toWhereTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.toWhereTextBox.Location = new System.Drawing.Point(206, 354);
            this.toWhereTextBox.Name = "toWhereTextBox";
            this.toWhereTextBox.ReadOnly = true;
            this.toWhereTextBox.Size = new System.Drawing.Size(266, 26);
            this.toWhereTextBox.TabIndex = 9;
            // 
            // beforeLabel
            // 
            this.beforeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.beforeLabel.AutoSize = true;
            this.beforeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beforeLabel.Location = new System.Drawing.Point(80, 393);
            this.beforeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.beforeLabel.Name = "beforeLabel";
            this.beforeLabel.Size = new System.Drawing.Size(67, 25);
            this.beforeLabel.TabIndex = 14;
            this.beforeLabel.Text = "before";
            // 
            // beforeTextBox
            // 
            this.beforeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.beforeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.beforeTextBox.Location = new System.Drawing.Point(206, 394);
            this.beforeTextBox.Name = "beforeTextBox";
            this.beforeTextBox.ReadOnly = true;
            this.beforeTextBox.Size = new System.Drawing.Size(266, 26);
            this.beforeTextBox.TabIndex = 10;
            // 
            // afterLabel
            // 
            this.afterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.afterLabel.AutoSize = true;
            this.afterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterLabel.Location = new System.Drawing.Point(80, 433);
            this.afterLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.afterLabel.Name = "afterLabel";
            this.afterLabel.Size = new System.Drawing.Size(50, 25);
            this.afterLabel.TabIndex = 15;
            this.afterLabel.Text = "after";
            // 
            // afterTextBox
            // 
            this.afterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.afterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.afterTextBox.Location = new System.Drawing.Point(206, 434);
            this.afterTextBox.Name = "afterTextBox";
            this.afterTextBox.ReadOnly = true;
            this.afterTextBox.Size = new System.Drawing.Size(266, 26);
            this.afterTextBox.TabIndex = 11;
            // 
            // ifLabel
            // 
            this.ifLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ifLabel.AutoSize = true;
            this.ifLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ifLabel.Location = new System.Drawing.Point(80, 473);
            this.ifLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ifLabel.Name = "ifLabel";
            this.ifLabel.Size = new System.Drawing.Size(21, 25);
            this.ifLabel.TabIndex = 16;
            this.ifLabel.Text = "if";
            // 
            // ifTextBox
            // 
            this.ifTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ifTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ifTextBox.Location = new System.Drawing.Point(206, 474);
            this.ifTextBox.Name = "ifTextBox";
            this.ifTextBox.ReadOnly = true;
            this.ifTextBox.Size = new System.Drawing.Size(266, 26);
            this.ifTextBox.TabIndex = 12;
            // 
            // currentNeededLabel
            // 
            this.currentNeededLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.currentNeededLabel.AutoSize = true;
            this.currentNeededLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentNeededLabel.ForeColor = System.Drawing.Color.Red;
            this.currentNeededLabel.Location = new System.Drawing.Point(182, 516);
            this.currentNeededLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.currentNeededLabel.Name = "currentNeededLabel";
            this.currentNeededLabel.Size = new System.Drawing.Size(20, 25);
            this.currentNeededLabel.TabIndex = 17;
            this.currentNeededLabel.Text = "*";
            this.currentNeededLabel.Visible = false;
            // 
            // currentLabel
            // 
            this.currentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.currentLabel.AutoSize = true;
            this.currentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLabel.Location = new System.Drawing.Point(80, 513);
            this.currentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(72, 25);
            this.currentLabel.TabIndex = 18;
            this.currentLabel.Text = "current";
            // 
            // currentTextBox
            // 
            this.currentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.currentTextBox.Location = new System.Drawing.Point(206, 514);
            this.currentTextBox.Name = "currentTextBox";
            this.currentTextBox.ReadOnly = true;
            this.currentTextBox.Size = new System.Drawing.Size(266, 26);
            this.currentTextBox.TabIndex = 13;
            // 
            // valueNeededLabel
            // 
            this.valueNeededLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.valueNeededLabel.AutoSize = true;
            this.valueNeededLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueNeededLabel.ForeColor = System.Drawing.Color.Red;
            this.valueNeededLabel.Location = new System.Drawing.Point(22, 568);
            this.valueNeededLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.valueNeededLabel.Name = "valueNeededLabel";
            this.valueNeededLabel.Size = new System.Drawing.Size(20, 25);
            this.valueNeededLabel.TabIndex = 20;
            this.valueNeededLabel.Text = "*";
            this.valueNeededLabel.Visible = false;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueTextBox.Location = new System.Drawing.Point(45, 567);
            this.valueTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.ReadOnly = true;
            this.valueTextBox.Size = new System.Drawing.Size(453, 26);
            this.valueTextBox.TabIndex = 14;
            // 
            // actionOpenLabel2
            // 
            this.actionOpenLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionOpenLabel2.AutoSize = true;
            this.actionOpenLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionOpenLabel2.Location = new System.Drawing.Point(480, 513);
            this.actionOpenLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.actionOpenLabel2.Name = "actionOpenLabel2";
            this.actionOpenLabel2.Size = new System.Drawing.Size(24, 25);
            this.actionOpenLabel2.TabIndex = 19;
            this.actionOpenLabel2.Text = ">";
            // 
            // actionCloseLabel1
            // 
            this.actionCloseLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionCloseLabel1.AutoSize = true;
            this.actionCloseLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionCloseLabel1.Location = new System.Drawing.Point(8, 611);
            this.actionCloseLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.actionCloseLabel1.Name = "actionCloseLabel1";
            this.actionCloseLabel1.Size = new System.Drawing.Size(30, 25);
            this.actionCloseLabel1.TabIndex = 21;
            this.actionCloseLabel1.Text = "</";
            // 
            // actionTextBox
            // 
            this.actionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.actionTextBox.Location = new System.Drawing.Point(39, 611);
            this.actionTextBox.Name = "actionTextBox";
            this.actionTextBox.ReadOnly = true;
            this.actionTextBox.Size = new System.Drawing.Size(90, 26);
            this.actionTextBox.TabIndex = 15;
            // 
            // actionCloseLabel2
            // 
            this.actionCloseLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionCloseLabel2.AutoSize = true;
            this.actionCloseLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionCloseLabel2.Location = new System.Drawing.Point(137, 611);
            this.actionCloseLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.actionCloseLabel2.Name = "actionCloseLabel2";
            this.actionCloseLabel2.Size = new System.Drawing.Size(24, 25);
            this.actionCloseLabel2.TabIndex = 22;
            this.actionCloseLabel2.Text = ">";
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(218, 611);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(167, 25);
            this.errorLabel.TabIndex = 23;
            this.errorLabel.Text = "Regola non valida";
            this.errorLabel.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(397, 609);
            this.okButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(101, 28);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkBtnClicked);
            // 
            // RuleCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 653);
            this.Controls.Add(this.actionOpenLabel1);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.nameNeededLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.fromNeededLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.fromTextBox);
            this.Controls.Add(this.formWhereLabel);
            this.Controls.Add(this.fromWhereTextBox);
            this.Controls.Add(this.inNeededLabel);
            this.Controls.Add(this.inLabel);
            this.Controls.Add(this.inTextBox);
            this.Controls.Add(this.whereLabel);
            this.Controls.Add(this.whereTextBox);
            this.Controls.Add(this.toNeededLabel);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.toWhereLabel);
            this.Controls.Add(this.toWhereTextBox);
            this.Controls.Add(this.beforeLabel);
            this.Controls.Add(this.beforeTextBox);
            this.Controls.Add(this.afterLabel);
            this.Controls.Add(this.afterTextBox);
            this.Controls.Add(this.ifLabel);
            this.Controls.Add(this.ifTextBox);
            this.Controls.Add(this.currentNeededLabel);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.currentTextBox);
            this.Controls.Add(this.actionOpenLabel2);
            this.Controls.Add(this.valueNeededLabel);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.actionCloseLabel1);
            this.Controls.Add(this.actionTextBox);
            this.Controls.Add(this.actionCloseLabel2);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(820, 700);
            this.MinimumSize = new System.Drawing.Size(500, 700);
            this.Name = "RuleCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form di creazione";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label actionOpenLabel1;
        public System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.Label typeLabel;
        public System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label nameNeededLabel;
        private System.Windows.Forms.Label nameLabel;
        public System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label fromNeededLabel;
        private System.Windows.Forms.Label fromLabel;
        public System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label formWhereLabel;
        public System.Windows.Forms.TextBox fromWhereTextBox;
        private System.Windows.Forms.Label inNeededLabel;
        private System.Windows.Forms.Label inLabel;
        public System.Windows.Forms.TextBox inTextBox;
        private System.Windows.Forms.Label whereLabel;
        public System.Windows.Forms.TextBox whereTextBox;
        private System.Windows.Forms.Label toNeededLabel;
        private System.Windows.Forms.Label toLabel;
        public System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label toWhereLabel;
        public System.Windows.Forms.TextBox toWhereTextBox;
        private System.Windows.Forms.Label beforeLabel;
        public System.Windows.Forms.TextBox beforeTextBox;
        private System.Windows.Forms.Label afterLabel;
        public System.Windows.Forms.TextBox afterTextBox;
        private System.Windows.Forms.Label ifLabel;
        public System.Windows.Forms.TextBox ifTextBox;
        private System.Windows.Forms.Label currentNeededLabel;
        private System.Windows.Forms.Label currentLabel;
        public System.Windows.Forms.TextBox currentTextBox;
        private System.Windows.Forms.Label actionOpenLabel2;
        private System.Windows.Forms.Label valueNeededLabel;
        public System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label actionCloseLabel1;
        private System.Windows.Forms.TextBox actionTextBox;
        private System.Windows.Forms.Label actionCloseLabel2;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button okButton;
    }
}