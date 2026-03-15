using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Entities
{
    public class CodeGenericModel
    {
        public List<modelProject> Projects { get; set; }
        public List<ModelTask> Tasks { get; set; }
        public List<ModelDeveloper> Developers { get; set; }
        public List<ModelPriority> Priority { get; set; }
    }

    public class modelProject
    {
        public int StatusProjectId { get; set; }
        public string StatusProject { get; set; }
    }
    public class ModelTask
    {
        public int StatusTaskId { get; set; }
        public string StatusTask { get; set; }
    }

    public class ModelDeveloper
    {
        public int DeveloperId { get; set; }
        public string FullName { get; set; }
    }

    public class ModelPriority
    {
        public int StatusPriorityId { get; set; }
        public string StatusPriority { get; set; }
    }


}
