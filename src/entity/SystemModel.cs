namespace nuoqin.src.entity
{
    public class SystemModel
    {

        public SystemModel(string text, string commond)
        {
            this.Text = text;
            this.Commond = commond;
        }

        public string Text { get; set; }


        public string Commond { get; set; }


    }
}
