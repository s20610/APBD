using System.Xml.Serialization;

namespace Cwiczenie2.Models
{
    public class ActiveStudy
    {
        
        [XmlAttribute(AttributeName = "name")]
        public string Name;

        [XmlAttribute(AttributeName = "numberOfStudents")]
        public int NumberOfStudents = 0;

        public ActiveStudy()
        {
        }
        
        public ActiveStudy(string name)
        {
            this.Name = name;
        }
    }
}