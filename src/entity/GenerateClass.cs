using System;

namespace nuoqin.src.entity
{
    public class GenerateClass
    {
        private String name;

        private String author;

        public GenerateClass(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

        public GenerateClass()
        {
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setAuthor(String author)
        {
            this.author = author;
        }

        public String getName()
        {
            return this.name;
        }

        public String getAuthor() { return this.author; }

    }
}
