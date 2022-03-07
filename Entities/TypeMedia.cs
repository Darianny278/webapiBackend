using System.Collections.Generic;

namespace backend.Entities {
    public class TypeMedia {
        public int Id{get; set;}
        public string Name{get;set;}
        public virtual IEnumerable<Media> Medias{get;set;}
    }
}