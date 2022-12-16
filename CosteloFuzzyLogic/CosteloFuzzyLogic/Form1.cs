using System;
using System.Windows.Forms;
using DotFuzzy;
namespace CosteloFuzzyLogic
{
    public partial class Form1 : Form
    {
        FuzzyEngine fe;
        MembershipFunctionCollection temperature,level,knob;
        LinguisticVariable myTemperature, myLevel, myKnob;
        FuzzyRuleCollection myrules;

        const double targetTemperature = 80;
        double heat = 0;

        public Form1()
        {
            InitializeComponent();
        }

    
        public void setMembers()
        {
            //  membership functions for temperature
            temperature = new MembershipFunctionCollection();
            temperature.Add(new MembershipFunction("XSMALL",0.0,9.0,9.0,20.0));
            temperature.Add(new MembershipFunction("SMALL", 10.0, 30.0, 30.0, 40.0));
            temperature.Add(new MembershipFunction("MEDIUM", 30.0, 55.0, 55.0, 75.0));
            temperature.Add(new MembershipFunction("LARGE", 60.0, 80.0, 80.0, 95.0));
            temperature.Add(new MembershipFunction("XLARGE", 85.0, 100.0, 100.0, 125.0));
            myTemperature = new LinguisticVariable("TEMPERATURE", temperature);

            //  membership functions for level
            level = new MembershipFunctionCollection();
            level.Add(new MembershipFunction("XSMALL", 0.0, 1.0, 1.0, 2.0));
            level.Add(new MembershipFunction("SMALL", 1.5, 2.5, 2.5, 4.0));
            level.Add(new MembershipFunction("MEDIUM", 3.0, 5.0, 5.0, 7.0));
            level.Add(new MembershipFunction("LARGE", 6.0, 7.5, 7.5, 8.5));
            level.Add(new MembershipFunction("XLARGE", 7.5, 8.75, 8.75, 10.0));
            myLevel = new LinguisticVariable("LEVEL", level);

            //  membership functions for knob
            knob = new MembershipFunctionCollection();
            knob.Add(new MembershipFunction("VERYLITTLE",0.0,1.0,1.0,2.0));
            knob.Add(new MembershipFunction("ALITTLE", 1.5, 2.75, 2.75, 4.0));
            knob.Add(new MembershipFunction("AGOODAMOUNT", 3.0, 5.0, 5.0, 7.0));
            knob.Add(new MembershipFunction("ALOT", 6.0, 7.75, 7.75, 8.5));
            knob.Add(new MembershipFunction("AWHOLELOT", 7.5, 9.0, 9.0, 10.0));
            myKnob = new LinguisticVariable("KNOB", knob);

            
        
        }

        public void setRules()
        {
          
          myrules = new FuzzyRuleCollection();

          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XSMALL) AND (LEVEL IS XSMALL) THEN KNOB IS AGOODAMOUNT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XSMALL) AND (LEVEL IS SMALL) THEN KNOB IS ALOT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XSMALL) AND (LEVEL IS MEDIUM) THEN KNOB IS AWHOLELOT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XSMALL) AND (LEVEL IS LARGE) THEN KNOB IS AWHOLELOT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XSMALL) AND (LEVEL IS XLARGE) THEN KNOB IS AWHOLELOT"));

          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS SMALL) AND (LEVEL IS XSMALL) THEN KNOB IS ALITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS SMALL) AND (LEVEL IS SMALL) THEN KNOB IS AGOODAMOUNT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS SMALL) AND (LEVEL IS MEDIUM) THEN KNOB IS ALOT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS SMALL) AND (LEVEL IS LARGE) THEN KNOB IS ALOT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS SMALL) AND (LEVEL IS XLARGE) THEN KNOB IS ALOT"));

          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS MEDIUM) AND (LEVEL IS XSMALL) THEN KNOB IS VERYLITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS MEDIUM) AND (LEVEL IS SMALL) THEN KNOB IS VERYLITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS MEDIUM) AND (LEVEL IS MEDIUM) THEN KNOB IS AGOODAMOUNT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS MEDIUM) AND (LEVEL IS LARGE) THEN KNOB IS ALOT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS MEDIUM) AND (LEVEL IS XLARGE) THEN KNOB IS ALOT"));

          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS LARGE) AND (LEVEL IS XSMALL) THEN KNOB IS VERYLITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS LARGE) AND (LEVEL IS SMALL) THEN KNOB IS VERYLITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS LARGE) AND (LEVEL IS MEDIUM) THEN KNOB IS ALITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS LARGE) AND (LEVEL IS LARGE) THEN KNOB IS AGOODAMOUNT"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS LARGE) AND (LEVEL IS XLARGE) THEN KNOB IS ALITTLE"));

          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XLARGE) AND (LEVEL IS XSMALL) THEN KNOB IS VERYLITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XLARGE) AND (LEVEL IS SMALL) THEN KNOB IS VERYLITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XLARGE) AND (LEVEL IS MEDIUM) THEN KNOB IS VERYLITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XLARGE) AND (LEVEL IS LARGE) THEN KNOB IS ALITTLE"));
          myrules.Add(new FuzzyRule("IF (TEMPERATURE IS XLARGE) AND (LEVEL IS XLARGE) THEN KNOB IS AGOODAMOUNT"));
        }

        public void setFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myTemperature);
            fe.LinguisticVariableCollection.Add(myLevel);
            fe.LinguisticVariableCollection.Add(myKnob);
            fe.FuzzyRuleCollection = myrules;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void defuziffyToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMembers();
            setRules();
            //setFuzzyEngine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myTemperature.InputValue=(Convert.ToDouble(textBox1.Text));
            myTemperature.Fuzzify("XLARGE");
            
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            myLevel.InputValue = (Convert.ToDouble(textBox2.Text));
            myLevel.Fuzzify("XLARGE");
            
        }

        public void fuziffyvalues()
        {
            myTemperature.InputValue = (Convert.ToDouble(textBox1.Text));
            myTemperature.Fuzzify("XSMALL");

            myLevel.InputValue = (Convert.ToDouble(textBox2.Text));
            myLevel.Fuzzify("XSMALL");

            myKnob.InputValue = (Convert.ToDouble(textBox2.Text));
            myKnob.Fuzzify("VERYLITTLE");

        }
        public void defuzzy()
        {
            setFuzzyEngine();
            fe.Consequent = "KNOB";
            heat = fe.Defuzzify();
            textBox3.Text = "" + heat;
        }

        public void ComputeNewTemperature()
        {

            double oldTemp = Convert.ToDouble(textBox1.Text);
            double oldKnob = Convert.ToDouble(textBox3.Text);
            double oldLevel = Convert.ToDouble(textBox2.Text);
            double newTemp = oldTemp;
            if (oldTemp < targetTemperature)
                newTemp += heat;
            else
                newTemp -= heat;
            textBox1.Text = "" + newTemp;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            setFuzzyEngine();
            fe.Consequent = "KNOB";
            textBox3.Text = "" + fe.Defuzzify();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ComputeNewTemperature();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            setMembers();
            setRules();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fuziffyvalues();
            defuzzy();
            ComputeNewTemperature();
        }

       
    }
}
