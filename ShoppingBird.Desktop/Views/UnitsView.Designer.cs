
namespace ShoppingBird.Desktop.Views
{
    partial class UnitsView
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitsView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControlUnits = new DevExpress.XtraGrid.GridControl();
            this.gridViewUnits = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEditUnitDescription = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonInsertUnit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSaveUnit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditUnit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditUnitId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUnitDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUnitId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControlUnits);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel2.Controls.Add(this.textEditUnitDescription);
            this.splitContainer1.Panel2.Controls.Add(this.simpleButtonInsertUnit);
            this.splitContainer1.Panel2.Controls.Add(this.simpleButtonSaveUnit);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel2.Controls.Add(this.textEditUnit);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel2.Controls.Add(this.textEditUnitId);
            this.splitContainer1.Size = new System.Drawing.Size(1074, 555);
            this.splitContainer1.SplitterDistance = 809;
            this.splitContainer1.TabIndex = 1;
            // 
            // gridControlUnits
            // 
            this.gridControlUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUnits.Location = new System.Drawing.Point(0, 0);
            this.gridControlUnits.MainView = this.gridViewUnits;
            this.gridControlUnits.Name = "gridControlUnits";
            this.gridControlUnits.Size = new System.Drawing.Size(809, 555);
            this.gridControlUnits.TabIndex = 0;
            this.gridControlUnits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUnits});
            // 
            // gridViewUnits
            // 
            this.gridViewUnits.GridControl = this.gridControlUnits;
            this.gridViewUnits.Name = "gridViewUnits";
            this.gridViewUnits.OptionsBehavior.Editable = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(11, 166);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(99, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "UNIT DESCRIPTION";
            // 
            // textEditUnitDescription
            // 
            this.textEditUnitDescription.EditValue = "";
            this.textEditUnitDescription.Location = new System.Drawing.Point(11, 185);
            this.textEditUnitDescription.Name = "textEditUnitDescription";
            this.textEditUnitDescription.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEditUnitDescription.Properties.Appearance.Options.UseFont = true;
            this.textEditUnitDescription.Size = new System.Drawing.Size(234, 42);
            this.textEditUnitDescription.TabIndex = 11;
            // 
            // simpleButtonInsertUnit
            // 
            this.simpleButtonInsertUnit.Location = new System.Drawing.Point(110, 293);
            this.simpleButtonInsertUnit.Name = "simpleButtonInsertUnit";
            this.simpleButtonInsertUnit.Size = new System.Drawing.Size(135, 23);
            this.simpleButtonInsertUnit.TabIndex = 10;
            this.simpleButtonInsertUnit.Text = "New [ Insert ]";
            // 
            // simpleButtonSaveUnit
            // 
            this.simpleButtonSaveUnit.Location = new System.Drawing.Point(110, 264);
            this.simpleButtonSaveUnit.Name = "simpleButtonSaveUnit";
            this.simpleButtonSaveUnit.Size = new System.Drawing.Size(135, 23);
            this.simpleButtonSaveUnit.TabIndex = 9;
            this.simpleButtonSaveUnit.Text = "Save [ F6 ]";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "UNIT";
            // 
            // textEditUnit
            // 
            this.textEditUnit.EditValue = "";
            this.textEditUnit.Location = new System.Drawing.Point(11, 112);
            this.textEditUnit.Name = "textEditUnit";
            this.textEditUnit.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEditUnit.Properties.Appearance.Options.UseFont = true;
            this.textEditUnit.Size = new System.Drawing.Size(234, 42);
            this.textEditUnit.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "UNIT ID";
            // 
            // textEditUnitId
            // 
            this.textEditUnitId.EditValue = "";
            this.textEditUnitId.Location = new System.Drawing.Point(11, 38);
            this.textEditUnitId.Name = "textEditUnitId";
            this.textEditUnitId.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEditUnitId.Properties.Appearance.Options.UseFont = true;
            this.textEditUnitId.Properties.ReadOnly = true;
            this.textEditUnitId.Size = new System.Drawing.Size(234, 42);
            this.textEditUnitId.TabIndex = 5;
            // 
            // UnitsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 555);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "UnitsView";
            this.Text = "Units View";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUnitDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUnitId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControlUnits;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUnits;
        private DevExpress.XtraEditors.SimpleButton simpleButtonInsertUnit;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveUnit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditUnit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditUnitId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEditUnitDescription;
    }
}