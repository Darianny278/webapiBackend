using System.Collections.Generic;

namespace backend.Entities {
    public class Category {
        public int Id{get; set;}
        public string NameCategory{get; set;}

       public virtual IEnumerable<Media> Medias {get; set;}
    }
}