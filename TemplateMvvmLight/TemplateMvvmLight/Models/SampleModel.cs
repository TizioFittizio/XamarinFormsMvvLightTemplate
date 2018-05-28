using System.Collections.Generic;

namespace TemplateMvvmLight.Models
{
    public class SampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> Items { get; set; }
    }
}
