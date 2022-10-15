using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Data.Seeder
{
    public class DbSeeder
    {
        public static async void Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if(!context.Status.Any())
            {
                var status = new List<Status>
                {
                    new Status { Description = "Activo", Entity = "General" },
                    new Status { Description = "Inactivo", Entity = "General" },
                };
                await context.Status.AddRangeAsync(status);
                await context.SaveChangesAsync();
            }

            if(!context.DocumentTypes.Any())
            {
                var documentTypes = new List<DocumentType>
                {
                    new DocumentType { Description = "Documento Nacional de Identidad", Abbreviation = "DNI" },
                    new DocumentType { Description = "Carnet de Extranjería", Abbreviation = "CE" }
                };
                await context.DocumentTypes.AddRangeAsync(documentTypes);
                await context.SaveChangesAsync();
            }

            if(!context.Ubigeos.Any())
            {
                var ubigeos = new List<Ubigeo>
                {
                    new Ubigeo { Citizenship = "Peruana", CountryCode = "PE", CountryName = "Peru", DepartmentCode = "LIM", DepartmentName = "Lima", ProvinceCode = "LIM", ProvinceName = "Lima", DistrictCode = "1601", DistrictName = "Ate" }
                };
                await context.Ubigeos.AddRangeAsync(ubigeos);
                await context.SaveChangesAsync();
            }

            if (!context.Companies.Any())
            {
                var status = await context.Status.ToListAsync();
                var companies = new List<Company>
                {
                    new Company { Description = "Prueba", Address = "Prueba", Code = "123", StatusId = status[0].Id },
                };
                await context.Companies.AddRangeAsync(companies);
                await context.SaveChangesAsync();
            }

            if(!context.CompanyHeadquarters.Any())
            {
                var status = await context.Status.ToListAsync();
                var companies = await context.Companies.ToListAsync();
                var companyHeadquarters = new List<CompanyHeadquarter>
                {
                    new CompanyHeadquarter { Description = "Prueba 1", Address = "Prueba", CompanyId = companies[0].Id, StatusId = status[0].Id },
                    new CompanyHeadquarter { Description = "Prueba 2", Address = "Prueba", CompanyId = companies[0].Id, StatusId = status[0].Id },
                };
                await context.CompanyHeadquarters.AddRangeAsync(companyHeadquarters);
                await context.SaveChangesAsync();
            }

            if(!context.PointsOfSale.Any())
            {
                var status = await context.Status.ToListAsync();
                var companyHeadquarters = await context.CompanyHeadquarters.ToListAsync();
                var pointOfSales = new List<PointOfSale>
                {
                    new PointOfSale { Description = "Punto de Venta 1", CompanyHeadquarterId = companyHeadquarters[0].Id, StatusId = status[0].Id },
                    new PointOfSale { Description = "Punto de Venta 2", CompanyHeadquarterId = companyHeadquarters[0].Id, StatusId = status[0].Id },
                    new PointOfSale { Description = "Punto de Venta 3", CompanyHeadquarterId = companyHeadquarters[1].Id, StatusId = status[0].Id },
                };
                await context.PointsOfSale.AddRangeAsync(pointOfSales);
                await context.SaveChangesAsync();
            }

            if (!context.WorkAreas.Any())
            {
                var workAreas = new List<WorkArea>
                {
                    new WorkArea { Description = "Gerencia" },
                    new WorkArea { Description = "Tecnologías de la Información" },
                    new WorkArea { Description = "Diseño" },
                    new WorkArea { Description = "Marketing" },
                    new WorkArea { Description = "Recursos Humanos" },
                };
                await context.WorkAreas.AddRangeAsync(workAreas);
                await context.SaveChangesAsync();
            }

            if(!context.WorkPositions.Any())
            {
                var workPositions = new List<WorkPosition>
                {
                    new WorkPosition { Description = "CTO" },
                    new WorkPosition { Description = "Programador" },
                };
                await context.WorkPositions.AddRangeAsync(workPositions);
                await context.SaveChangesAsync();
            }

            if (!context.Employees.Any())
            {
                var status = await context.Status.ToListAsync();
                var companies = await context.Companies.ToListAsync();
                var documentTypes = await context.DocumentTypes.ToListAsync();
                var ubigeos = await context.Ubigeos.ToListAsync();
                var workAreas = await context.WorkAreas.ToListAsync();
                var workPositions = await context.WorkPositions.ToListAsync();
                var employees = new List<Employee>
                {
                    new Employee { FirstName = "Luis Jeffrey", LastName = "Rojas Montes", Document = "74804725", CompanyId = companies[0].Id, StatusId = status[0].Id, DocumentTypeId = documentTypes[0].Id, UbigeoId = ubigeos[0].Id, WorkAreaId = workAreas[1].Id, WorkPositionId = workPositions[1].Id },
                    new Employee { FirstName = "Pablo", LastName = "Zosimo", Document = "10254488", CompanyId = companies[0].Id, StatusId = status[0].Id, DocumentTypeId = documentTypes[0].Id, UbigeoId = ubigeos[0].Id, WorkAreaId = workAreas[1].Id, WorkPositionId = workPositions[1].Id }
                };
                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();
            }

            if(!context.RoomStatus.Any())
            {
                var roomStatus = new List<RoomStatus>
                {
                    new RoomStatus { Description = "Disponible" },
                    new RoomStatus { Description = "Sucio" },
                    new RoomStatus { Description = "En Limpieza" },
                    new RoomStatus { Description = "Mantenimiento" },
                    new RoomStatus { Description = "Ocupado" },
                };
                await context.RoomStatus.AddRangeAsync(roomStatus);
                await context.SaveChangesAsync();
            }

            if(!context.RoomTypes.Any())
            {
                var roomTypes = new List<RoomType>
                {
                    new RoomType { Description = "Matrimonial" }, 
                    new RoomType { Description = "Doble" }, 
                    new RoomType { Description = "Triple" }, 
                    new RoomType { Description = "Suite Queen" }, 
                    new RoomType { Description = "Ejecutivo" },
                    new RoomType { Description = "Suite King" },
                };
                await context.RoomTypes.AddRangeAsync(roomTypes);
                await context.SaveChangesAsync();
            }

            if(!context.PersonTypes.Any())
            {
                var personTypes = new List<PersonType>
                {
                    new PersonType { Description = "Persona Natural" }
                };
                await context.PersonTypes.AddRangeAsync(personTypes);
                await context.SaveChangesAsync();
            }

            if (userManager.FindByEmailAsync("sysadmin@erpxcore.com").Result == null)
            {
                var employees = await context.Employees.ToListAsync();
                var status = await context.Status.ToListAsync();
                var user = new ApplicationUser
                {
                    UserName = "sysadmin@erpxcore.com",
                    Email = "sysadmin@erpxcore.com",
                    PhoneNumber = "999999999",
                    EmployeeId = employees[0].Id,
                    StatusId = status[0].Id,
                    EmailConfirmed = true,
                };

                var result = userManager.CreateAsync(user, "XCore.2022").Result;
            }

            if (userManager.FindByEmailAsync("nuevousuario@erpxcore.com").Result == null)
            {
                var employees = await context.Employees.ToListAsync();
                var status = await context.Status.ToListAsync();
                var user = new ApplicationUser
                {
                    UserName = "nuevousuario@erpxcore.com",
                    Email = "nuevousuario@erpxcore.com",
                    PhoneNumber = "999999999",
                    EmployeeId = employees[1].Id,
                    StatusId = status[0].Id,
                    EmailConfirmed = true,
                };

                var result = userManager.CreateAsync(user, "XCore.2022").Result;
            }

            if(roleManager.FindByNameAsync("Prueba").Result == null)
            {
                var role = new ApplicationRole("Prueba");
                await roleManager.CreateAsync(role);
            }

            if(!userManager.GetUsersInRoleAsync("Prueba").Result.Any())
            {
                var user = await userManager.FindByEmailAsync("sysadmin@erpxcore.com");
                await userManager.AddToRoleAsync(user, "Prueba");
            }

            if (!context.PermissionLevels.Any())
            {
                var permissionLevels = new List<PermissionLevel>
                {
                    new PermissionLevel { Description = Constants.Permission.CREATE },
                    new PermissionLevel { Description = Constants.Permission.READ },
                    new PermissionLevel { Description = Constants.Permission.UPDATE },
                    new PermissionLevel { Description = Constants.Permission.DELETE },
                };

                await context.PermissionLevels.AddRangeAsync(permissionLevels);
                await context.SaveChangesAsync();
            }

            if (!context.Modules.Any())
            {
                var modules = new List<Module>
                {
                    new Module { Description = "Generales" },
                    new Module { Description = "Empresas" },
                    new Module { Description = "Seguridad" },
                };

                await context.Modules.AddRangeAsync(modules);
                await context.SaveChangesAsync();
            }

            if(!context.SubModules.Any())
            {
                var modules = await context.Modules.ToListAsync();
                var subModules = new List<SubModule>
                {
                    new SubModule { Description = "Tipo Documento", ModuleId = modules[0].Id, RouteUrl = "/maestros/generales/tipo-de-documento" },
                    new SubModule { Description = "Ubigeo", ModuleId = modules[0].Id, RouteUrl = "/maestros/generales/ubigeo" },
                    new SubModule { Description = "Estado", ModuleId = modules[0].Id, RouteUrl = "/maestros/generales/estado" },
                };

                await context.SubModules.AddRangeAsync(subModules);
                await context.SaveChangesAsync();
            }


            if (!context.Permissions.Any())
            {
                var role = await roleManager.FindByNameAsync("Prueba");
                var subModules = await context.SubModules.ToListAsync();
                var permissionLevels = await context.PermissionLevels.ToListAsync();
                var permissions = new List<Permission>
                {
                    new Permission { RoleId = role.Id, SubModuleId = subModules[0].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[0].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[0].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[0].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[1].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[1].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[1].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[2].Id, PermissionLevelId = permissionLevels[0].Id, },
                };

                await context.Permissions.AddRangeAsync(permissions);
                await context.SaveChangesAsync();
            }

        }
    }
}
