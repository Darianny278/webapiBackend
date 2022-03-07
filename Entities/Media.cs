namespace backend.Entities {
    public class Media {
        public int Id {get;set;}
        public string NameMedia {get;set;}
        public string DescriptionMedia{get;set;}
        public int CategoryId {get; set;}

        public Category Category{get; set;}
        public int TypeMediaId {get; set;}

        public TypeMedia TypeMedia{get; set;}
    }
}