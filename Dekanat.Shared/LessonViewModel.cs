using System;
using System.Collections.Generic;
using System.Text;

namespace Dekanat.Shared {
    public class LessonViewModel {
        public int Id { get; set; }

        public int Persone { get; set; }

        public bool Type { get; set; }

        public string Assessment { get; set; }

        public string Name { get; set; }

        public int Session { get; set; }
    }
}
