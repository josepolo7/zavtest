using System;
namespace zavtest.Model
{
    public class steelproCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }   
        //**********************************************************************
        public steelproCategory(int pId, string pName, string pType, string pImage){
            Id = pId;
            Name = pName;
            Type = pType;
            Image = pImage;
        }
        //**********************************************************************
    }
}
