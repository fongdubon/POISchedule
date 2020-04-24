namespace POISchedule.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using POISchedule.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext dataContext;

        public CombosHelper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboActivities()
        {
            var list = dataContext.Activities.Select(
                c => new SelectListItem
                {
                    Text = c.Name,
                    Value = $"{c.Id}"
                }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[debe seleccionar una actividad...]",
                Value = "0"
            });
            return list;
        }
    }
}
