using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearningProject.DAL.Entities
{
    public class CombinedModel
    {
        public PagedList.IPagedList<MyLearningProject.DAL.Entities.Course> PagedCourses { get; set; }
        public Tuple<List<MyLearningProject.DAL.Entities.Course>, List<int>> TupleModel { get; set; }
    }
}
