using OpsFlow.Core.Models;

namespace OpsFlow.Services.Helpers
{
    public static class ComboBoxHelper
    {
        public static Role? FindRoleByName(List<Role> roles, string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName) || roleName == "Rol seçiniz")
                return null;

            return roles.FirstOrDefault(r => r.RoleName == roleName);
        }

        public static Company? FindCompanyByName(List<Company> companies, string companyName)
        {
            if (string.IsNullOrWhiteSpace(companyName) || companyName == "Şirket seçiniz")
                return null;

            return companies.FirstOrDefault(c => c.CompanyName == companyName);
        }

        public static Department? FindDepartmentByName(List<Department> departments, string departmentName)
        {
            if (string.IsNullOrWhiteSpace(departmentName) || departmentName == "Departman seçiniz")
                return null;

            return departments.FirstOrDefault(d => d.DepartmentName == departmentName);
        }
    }
}