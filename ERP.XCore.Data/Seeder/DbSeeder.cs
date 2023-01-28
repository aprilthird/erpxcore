using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Data.Seeder
{
    public class DbSeeder
    {
        public static async void Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (!context.Status.Any())
            {
                var status = new List<Status>
                {
                    new Status { Description = "Activo", Entity = "General" },
                    new Status { Description = "Inactivo", Entity = "General" },
                };
                await context.Status.AddRangeAsync(status);
                await context.SaveChangesAsync();
            }

            if (!context.DocumentTypes.Any())
            {
                var documentTypes = new List<DocumentType>
                {
                    new DocumentType { Description = "Documento Nacional de Identidad", Abbreviation = "DNI" },
                    new DocumentType { Description = "Carnet de Extranjería", Abbreviation = "CE" }
                };
                await context.DocumentTypes.AddRangeAsync(documentTypes);
                await context.SaveChangesAsync();
            }

            if (!context.Ubigeos.Any())
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

            if (!context.CompanyHeadquarters.Any())
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

            if (!context.Currencies.Any())
            {
                var currencies = new List<Currency>
                {
                    new Currency { Code = "PEN", Description = "Nuevos Soles Peruanos", Sign = "S/" },
                };
                await context.Currencies.AddRangeAsync(currencies);
                await context.SaveChangesAsync();
            }

            if (!context.PointsOfSale.Any())
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

            if (!context.WorkPositions.Any())
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

            if (!context.RoomStatus.Any())
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

            if (!context.RoomTypes.Any())
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

            if (!context.PersonTypes.Any())
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

            if (roleManager.FindByNameAsync("Prueba").Result == null)
            {
                var role = new ApplicationRole("Prueba");
                await roleManager.CreateAsync(role);
            }

            if (!userManager.GetUsersInRoleAsync("Prueba").Result.Any())
            {
                var user = await userManager.FindByEmailAsync("nuevousuario@erpxcore.com");
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
                    new Module { Description = "Huespedes" },
                    new Module { Description = "Habitaciones" },
                    new Module { Description = "Seguridad" },
                };

                await context.Modules.AddRangeAsync(modules);
                await context.SaveChangesAsync();
            }

            if (!context.SubModules.Any())
            {
                var modules = await context.Modules.ToListAsync();
                var subModules = new List<SubModule>
                {
                    new SubModule { Description = "Tipo Documento", ModuleId = modules[0].Id, RouteUrl = "/maestros/generales/tipo-de-documento" },
                    new SubModule { Description = "Ubigeo", ModuleId = modules[0].Id, RouteUrl = "/maestros/generales/ubigeo" },
                    new SubModule { Description = "Estado", ModuleId = modules[0].Id, RouteUrl = "/maestros/generales/estado" },
                    new SubModule { Description = "Empresa", ModuleId = modules[1].Id, RouteUrl = "/maestros/empresas/empresa" },
                    new SubModule { Description = "Sede", ModuleId = modules[1].Id, RouteUrl = "/maestros/empresas/sede" },
                    new SubModule { Description = "POS", ModuleId = modules[1].Id, RouteUrl = "/maestros/empresas/pos" },
                    new SubModule { Description = "Colaborador", ModuleId = modules[1].Id, RouteUrl = "/maestros/empresas/colaborador" },
                    new SubModule { Description = "Area", ModuleId = modules[1].Id, RouteUrl = "/maestros/empresas/area" },
                    new SubModule { Description = "Cargo", ModuleId = modules[1].Id, RouteUrl = "/maestros/empresas/cargo" },
                    new SubModule { Description = "Cliente", ModuleId = modules[1].Id, RouteUrl = "/maestros/empresas/cliente" },
                    new SubModule { Description = "Huésped", ModuleId = modules[2].Id, RouteUrl = "/maestros/huespedes/huesped" },
                    new SubModule { Description = "Tipo Habitación", ModuleId = modules[3].Id, RouteUrl = "/maestros/habitaciones/tipo-de-habitacion" },
                    new SubModule { Description = "Estado Habitación", ModuleId = modules[3].Id, RouteUrl = "/maestros/habitaciones/estado-habitacion" },
                    new SubModule { Description = "Habitación", ModuleId = modules[3].Id, RouteUrl = "/maestros/habitaciones/habitacion" },
                    new SubModule { Description = "Cuenta Usuario", ModuleId = modules[4].Id, RouteUrl = "/maestros/seguridad/usuario" },
                    new SubModule { Description = "Permiso", ModuleId = modules[4].Id, RouteUrl = "/maestros/seguridad/permiso" },
                    new SubModule { Description = "Perfil", ModuleId = modules[4].Id, RouteUrl = "/maestros/seguridad/rol" },
                    new SubModule { Description = "Módulo", ModuleId = modules[4].Id, RouteUrl = "/maestros/seguridad/modulo" },
                    new SubModule { Description = "SubMódulo", ModuleId = modules[4].Id, RouteUrl = "/maestros/seguridad/submodulo" },

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
                    new Permission { RoleId = role.Id, SubModuleId = subModules[3].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[3].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[3].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[3].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[4].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[4].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[4].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[4].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[5].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[5].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[5].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[5].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[6].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[6].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[6].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[6].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[7].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[7].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[7].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[7].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[8].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[8].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[8].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[8].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[9].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[9].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[9].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[9].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[10].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[10].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[10].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[10].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[11].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[11].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[11].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[11].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[12].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[12].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[12].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[12].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[13].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[13].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[13].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[13].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[14].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[14].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[14].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[14].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[15].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[15].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[15].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[15].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[16].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[16].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[16].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[16].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[17].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[17].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[17].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[17].Id, PermissionLevelId = permissionLevels[3].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[18].Id, PermissionLevelId = permissionLevels[0].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[18].Id, PermissionLevelId = permissionLevels[1].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[18].Id, PermissionLevelId = permissionLevels[2].Id, },
                    new Permission { RoleId = role.Id, SubModuleId = subModules[18].Id, PermissionLevelId = permissionLevels[3].Id, },
                };

                await context.Permissions.AddRangeAsync(permissions);
                await context.SaveChangesAsync();
            }

            if (!context.Rooms.Any())
            {
                var types = await context.RoomTypes.ToListAsync();
                var roomStatus = await context.RoomStatus.ToListAsync();
                var status = await context.Status.ToListAsync();

                var rooms = new List<Room>
                {
                    new Room { Description = "101", RoomTypeId = types[0].Id, RoomStatusId = roomStatus[0].Id, StatusId = status[0].Id },
                    new Room { Description = "102", RoomTypeId = types[0].Id, RoomStatusId = roomStatus[0].Id, StatusId = status[0].Id },
                    new Room { Description = "103", RoomTypeId = types[1].Id, RoomStatusId = roomStatus[1].Id, StatusId = status[0].Id },
                    new Room { Description = "104", RoomTypeId = types[1].Id, RoomStatusId = roomStatus[2].Id, StatusId = status[0].Id },
                    new Room { Description = "105", RoomTypeId = types[2].Id, RoomStatusId = roomStatus[3].Id, StatusId = status[0].Id },
                    new Room { Description = "106", RoomTypeId = types[2].Id, RoomStatusId = roomStatus[0].Id, StatusId = status[0].Id },
                    new Room { Description = "107", RoomTypeId = types[3].Id, RoomStatusId = roomStatus[4].Id, StatusId = status[0].Id },
                    new Room { Description = "108", RoomTypeId = types[3].Id, RoomStatusId = roomStatus[4].Id, StatusId = status[0].Id },
                    new Room { Description = "109", RoomTypeId = types[4].Id, RoomStatusId = roomStatus[4].Id, StatusId = status[0].Id },

                    new Room { Description = "301", RoomTypeId = types[0].Id, RoomStatusId = roomStatus[2].Id, StatusId = status[0].Id },
                    new Room { Description = "302", RoomTypeId = types[1].Id, RoomStatusId = roomStatus[0].Id, StatusId = status[0].Id },
                    new Room { Description = "303", RoomTypeId = types[0].Id, RoomStatusId = roomStatus[0].Id, StatusId = status[0].Id },
                    new Room { Description = "304", RoomTypeId = types[2].Id, RoomStatusId = roomStatus[4].Id, StatusId = status[0].Id },
                    new Room { Description = "305", RoomTypeId = types[3].Id, RoomStatusId = roomStatus[2].Id, StatusId = status[0].Id },
                    new Room { Description = "306", RoomTypeId = types[3].Id, RoomStatusId = roomStatus[4].Id, StatusId = status[0].Id },
                    new Room { Description = "307", RoomTypeId = types[5].Id, RoomStatusId = roomStatus[2].Id, StatusId = status[0].Id },
                    new Room { Description = "308", RoomTypeId = types[5].Id, RoomStatusId = roomStatus[4].Id, StatusId = status[0].Id },
                    new Room { Description = "309", RoomTypeId = types[4].Id, RoomStatusId = roomStatus[4].Id, StatusId = status[0].Id },
                };

                await context.Rooms.AddRangeAsync(rooms);
                await context.SaveChangesAsync();
            }

            if (!context.Guests.Any())
            {
                var status = await context.Status.ToListAsync();
                var documentTypes = await context.DocumentTypes.ToListAsync();
                var ubigeos = await context.Ubigeos.ToListAsync();
                var guests = new List<Guest>
                {
                    new Guest { FirstName = "Luis Jeffrey", LastName = "Rojas Montes", Email = "jeffreyrm96@gmail.com", PhoneNumber = "994762307", UbigeoId = ubigeos[0].Id, DocumentTypeId = documentTypes[0].Id, Document = "74804725", StatusId = status[0].Id },
                };

                await context.Guests.AddRangeAsync(guests);
                await context.SaveChangesAsync();
            }

            if (!context.PaymentMethods.Any())
            {
                var paymentMethods = new List<PaymentMethod>
                {
                    new PaymentMethod { Description = "Pagar al Salir", RequiresAmount = false, RequiresVoucherNumber = false },
                    new PaymentMethod { Description = "Efectivo", RequiresAmount = true, RequiresVoucherNumber = false },
                    new PaymentMethod { Description = "Tarjeta de Crédito/Débito", RequiresAmount = true, RequiresVoucherNumber = true },
                    new PaymentMethod { Description = "Transferencia", RequiresAmount = true, RequiresVoucherNumber = true },
                    new PaymentMethod { Description = "Yape", RequiresAmount = true, RequiresVoucherNumber = false },
                };

                await context.PaymentMethods.AddRangeAsync(paymentMethods);
                await context.SaveChangesAsync();
            }

            if (!context.RoomCheckIns.Any())
            {
                var rooms = await context.Rooms.ToListAsync();
                var paymentMethods = await context.PaymentMethods.ToListAsync();
                var guests = await context.Guests.ToListAsync();
                var roomCheckIns = new List<RoomCheckIn>
                { 
                    new RoomCheckIn { RoomId = rooms[6].Id, Code = "1", EntryTime = DateTime.UtcNow, ExitTime = DateTime.UtcNow.AddDays(1), GuestId = guests[0].Id, PaymentMethodId = paymentMethods[0].Id, Nights = 1, ChargedAmount = 100, Amount = 100 },
                };

                await context.RoomCheckIns.AddRangeAsync(roomCheckIns);
                await context.SaveChangesAsync();
            }

            if(!context.RoomCheckInDetails.Any())
            {

            }

            if(!context.RoomCleanings.Any())
            {
                var rooms = await context.Rooms.ToListAsync();
                var employees = await context.Employees.ToListAsync();
                var roomCleanings = new List<RoomCleaning>
                {
                    new RoomCleaning { RoomId = rooms[3].Id, EmployeeId = employees[1].Id, StartedAt = DateTime.UtcNow },
                };

                await context.RoomCleanings.AddRangeAsync(roomCleanings);
                await context.SaveChangesAsync();
            }

            if(!context.RoomMaintenances.Any())
            {
                var rooms = await context.Rooms.ToListAsync();
                var employees = await context.Employees.ToListAsync();
                var roomMaintenances = new List<RoomMaintenance>
                {
                    new RoomMaintenance { RoomId = rooms[4].Id, EmployeeId = employees[1].Id, StartedAt = DateTime.UtcNow, Description = "Baño Atorado" },
                };

                await context.RoomMaintenances.AddRangeAsync(roomMaintenances);
                await context.SaveChangesAsync();
            }

            if (!context.FeeTypes.Any())
            {
                var currencies = await context.Currencies.ToListAsync();
                var feeTypes = new List<FeeType>
                {
                    new FeeType { Description = "Regular", CurrencyId = currencies[0].Id },
                    new FeeType { Description = "Premium", CurrencyId = currencies[0].Id },
				};
                await context.FeeTypes.AddRangeAsync(feeTypes);
                await context.SaveChangesAsync();
            }

            if (!context.Fees.Any())
            {
                var status = await context.Status.ToListAsync();
				var roomTypes = await context.RoomTypes.ToListAsync();
                var feeTypes = await context.FeeTypes.ToListAsync();
                var fees = new List<Fee>
                {
                    new Fee { RoomTypeId = roomTypes[0].Id, FeeTypeId = feeTypes[0].Id, StatusId = status[0].Id, Amount = 80 },
                    new Fee { RoomTypeId = roomTypes[1].Id, FeeTypeId = feeTypes[0].Id, StatusId = status[0].Id, Amount = 120 },
                    new Fee { RoomTypeId = roomTypes[2].Id, FeeTypeId = feeTypes[0].Id, StatusId = status[0].Id, Amount = 140 },
                    new Fee { RoomTypeId = roomTypes[3].Id, FeeTypeId = feeTypes[0].Id, StatusId = status[0].Id, Amount = 130 },
                    new Fee { RoomTypeId = roomTypes[4].Id, FeeTypeId = feeTypes[0].Id, StatusId = status[0].Id, Amount = 85 },
                    new Fee { RoomTypeId = roomTypes[5].Id, FeeTypeId = feeTypes[0].Id, StatusId = status[0].Id, Amount = 150 },
                };
                await context.Fees.AddRangeAsync(fees);
                await context.SaveChangesAsync();
            }
        }
    }
}

