using Forms.Engine;
using RoleGame;

namespace Forms
{
    public partial class Form1 : Form
    {
        Scene currentScene;

        public Form1()
        {
            this.currentScene = new Scene();
            InitializeComponent();
            Render.SetResolution(1000, 1000);
            Render.SetScene(currentScene);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.KeyValue==(char)currentScene.Config.KeyUp)
                this.currentScene.movePlayableCharacter(new Vector(0,-10));
            if (e.KeyValue == (char)currentScene.Config.KeyDown)
                this.currentScene.movePlayableCharacter(new Vector(0, 10));
            if (e.KeyValue == (char)currentScene.Config.KeyLeft)
                this.currentScene.movePlayableCharacter(new Vector(-10, 0));
            if (e.KeyValue == (char)currentScene.Config.KeyRight)
                this.currentScene.movePlayableCharacter(new Vector(10, 0));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.BackgroundImage = Render.DrawFrame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            characterGender gender = new characterGender();
            characterRace race = new characterRace();
            characterState state = new characterState();
            int xPos = Convert.ToInt32(this.textBox2.Text);
            int yPos = Convert.ToInt32(this.textBox3.Text);

            if(this.radioButton1.Checked==true)
                gender=characterGender.male;
            else
                gender = characterGender.female;

            if (this.radioButton3.Checked == true)
                race = characterRace.human;
            else if (this.radioButton4.Checked == true)
                race = characterRace.dwarf;
            else if (this.radioButton5.Checked == true)
                race = characterRace.elf;
            else if (this.radioButton6.Checked == true)
                race = characterRace.orc;
            else if (this.radioButton7.Checked == true)
                race = characterRace.goblin;

            if (this.radioButton8.Checked == true)
                state = characterState.normal;
            else if (this.radioButton9.Checked == true)
                state = characterState.weak;
            else if (this.radioButton10.Checked == true)
                state = characterState.sick;
            else if (this.radioButton11.Checked == true)
                state = characterState.poisoned;
            else if (this.radioButton12.Checked == true)
                state = characterState.paralyzed;
            else if (this.radioButton13.Checked == true)
                state = characterState.dead;

            this.currentScene.addObject(new Character(name, state,race, gender, new Vector(xPos, yPos), new Vector(100, 100),new Inventory()));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}