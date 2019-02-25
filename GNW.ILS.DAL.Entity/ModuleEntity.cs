namespace GNW.ILS.DAL.Entity
{
    public class ModuleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }
        public string ToolTip { get; set; }
        public string PathToLoad { get; set; }
    }
}
