using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset.model.dashboardModels;
using domain.office;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace presentation.dashboard.pages.category {
    public class EditModel: PageModel {
        #region ctor
        private readonly ICategory_Container _categoryContainer;
        public EditModel(ICategory_Container categoryContainer) {
            _categoryContainer = categoryContainer;
        }
        #endregion
        public async Task OnGetAsync() {
            //var result = await _categoryContainer.SingleAsync<Category_DashboardModel>(1);
            var result = await _categoryContainer.FindAllAsync(new domain.repository.entities.Category_Entity());
        }
    }
}