using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IMS.Core.Interface;
using IMS.Core.Model;

namespace IMS.DBImplimentation
{
    internal class IMSServiceImpl:IServiceImpl
    {
        #region Users

        public ICollection<AppUsers> GetAllAppUsers()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.AppUsers
                             select c).ToList();
            }
        }

        public AppUsers GetAppUserByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.AppUsers
                        where c.PK_appUsers == id
                        select c).FirstOrDefault();
            }
        }

        public AppUsers SaveAppUser(AppUsers user)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existinguser = (from c in dbContext.AppUsers
                                    where c.PK_appUsers == user.PK_appUsers
                                    select c).FirstOrDefault();

                if (existinguser != null)
                {
                    existinguser.IsActive = user.IsActive;
                    existinguser.IsAdmin = user.IsAdmin;
                    existinguser.UserCode = user.UserCode;
                    existinguser.UserName = user.UserName;
                    existinguser.UserPassword = user.UserPassword;
                    existinguser.ExpiryDate = user.ExpiryDate;
                    dbContext.Entry(existinguser).State = EntityState.Modified;
                }
                else
                {
                    if (user.PK_appUsers == null)
                        user.PK_appUsers = Guid.NewGuid();

                    dbContext.Entry(user).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return user;
            }
        }

        public void DeleteAppUserByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                AppUsers appuser = (from c in dbContext.AppUsers
                                    where c.PK_appUsers == id
                                    select c).FirstOrDefault();

                if (appuser != null)
                {
                    dbContext.Entry(appuser).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region User SubModules


        public ICollection<AppUsersModules> GetAllAppUsersModules(Guid userid)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.AppUsersModules
                        where c.FK_AppUsers == userid
                        select c).ToList();
            }
        }

        public AppUsersModules GetAppUsersModulesByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.AppUsersModules
                        where c.PK_AppUsersModules == id
                        select c).FirstOrDefault();
            }
        }

        public AppUsersModules SaveAppUsersModules(AppUsersModules userModules)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingUserModule = (from c in dbContext.AppUsersModules
                                    where c.PK_AppUsersModules == userModules.PK_AppUsersModules
                                    select c).FirstOrDefault();

                if (existingUserModule != null)
                {
                    existingUserModule.FK_MstrModules = userModules.FK_MstrModules;
                    existingUserModule.FK_AppUsers = userModules.FK_AppUsers;
                    existingUserModule.AllowToAdd = userModules.AllowToAdd;
                    existingUserModule.AllowToDelete = userModules.AllowToDelete;
                    existingUserModule.AllowToEdit = userModules.AllowToEdit;
                    existingUserModule.AllowToPost = userModules.AllowToPost;
                    existingUserModule.AllowToVoid = userModules.AllowToVoid;
                    dbContext.Entry(existingUserModule).State = EntityState.Modified;
                }
                else
                {
                    if (userModules.PK_AppUsersModules == null)
                        userModules.PK_AppUsersModules = Guid.NewGuid();

                    dbContext.Entry(userModules).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return userModules;
            }
        }

        public void DeleteAppUsersModulesByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                AppUsersModules appusermodule = (from c in dbContext.AppUsersModules
                                    where c.PK_AppUsersModules == id
                                    select c).FirstOrDefault();

                if (appusermodule != null)
                {
                    dbContext.Entry(appusermodule).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region Item Category

        public ICollection<MscItemCategory> GetAllItemCategory()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MscItemCategory
                        select c).ToList();
            }
        }

        public MscItemCategory GetItemCategoryByID(Int32 id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MscItemCategory
                        where c.PK_MscItemCategory == id
                        select c).FirstOrDefault();
            }
        }

        public MscItemCategory SaveItemCategory(MscItemCategory category)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingItemCategory = (from c in dbContext.MscItemCategory
                                          where c.PK_MscItemCategory == category.PK_MscItemCategory
                                          select c).FirstOrDefault();

                if (existingItemCategory != null)
                {
                    existingItemCategory.ItemCategory = category.ItemCategory;
                    dbContext.Entry(existingItemCategory).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Entry(category).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return category;
            }
        }

        public void DeleteItemCategoryByID(Int32 id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MscItemCategory itemcategory = (from c in dbContext.MscItemCategory
                                                 where c.PK_MscItemCategory == id
                                                 select c).FirstOrDefault();

                if (itemcategory != null)
                {
                    dbContext.Entry(itemcategory).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region Sub Classification

        public ICollection<MscSubClassification> GetAllSubClassification()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MscSubClassification
                        select c).ToList();
            }
        }

        public MscSubClassification GetSubClassificationByID(Int32 id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MscSubClassification
                        where c.PK_MscSubClassification == id
                        select c).FirstOrDefault();
            }
        }

        public MscSubClassification SaveSubClassification(MscSubClassification subclass)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingSubclass = (from c in dbContext.MscSubClassification
                                            where c.PK_MscSubClassification == subclass.PK_MscSubClassification
                                            select c).FirstOrDefault();

                if (existingSubclass != null)
                {
                    existingSubclass.SubClassification = subclass.SubClassification;
                    dbContext.Entry(existingSubclass).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Entry(subclass).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return subclass;
            }
        }

        public void DeleteSubClassificationByID(Int32 id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MscSubClassification subclassification = (from c in dbContext.MscSubClassification
                                                where c.PK_MscSubClassification == id
                                                select c).FirstOrDefault();

                if (subclassification != null)
                {
                    dbContext.Entry(subclassification).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region Agency

        public ICollection<MstrAgency> GetAllAgents()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrAgency
                        select c).ToList();
            }
        }

        public MstrAgency GetAgentByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrAgency
                        where c.PK_MstrAgency == id
                        select c).FirstOrDefault();
            }
        }

        public MstrAgency SaveAgent(MstrAgency agent)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingagent = (from c in dbContext.MstrAgency
                                    where c.PK_MstrAgency == agent.PK_MstrAgency
                                    select c).FirstOrDefault();

                if (existingagent != null)
                {
                    existingagent.IsActive = agent.IsActive;
                    existingagent.Address = agent.Address;
                    existingagent.Name = agent.Name;
                    dbContext.Entry(existingagent).State = EntityState.Modified;
                }
                else
                {
                    if (agent.PK_MstrAgency == null)
                        agent.PK_MstrAgency = Guid.NewGuid();

                    dbContext.Entry(agent).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return agent;
            }
        }

        public void DeleteAgentByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MstrAgency agent = (from c in dbContext.MstrAgency
                                    where c.PK_MstrAgency == id
                                    select c).FirstOrDefault();

                if (agent != null)
                {
                    dbContext.Entry(agent).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion
        
        #region Branches

        public ICollection<MstrBranches> GetAllBranches()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrBranches
                        select c).ToList();
            }
        }

        public MstrBranches GetBranchByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrBranches
                        where c.PK_MstrBranches == id
                        select c).FirstOrDefault();
            }
        }

        public MstrBranches SaveModule(MstrBranches branch)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingBranch = (from c in dbContext.MstrBranches
                                     where c.PK_MstrBranches == branch.PK_MstrBranches
                                     select c).FirstOrDefault();

                if (existingBranch != null)
                {
                    existingBranch.Address = branch.Address;
                    existingBranch.Area = branch.Area;
                    existingBranch.Branch = branch.Branch;
                    existingBranch.Classification = branch.Classification;
                    existingBranch.FK_MstrDealer = branch.FK_MstrDealer;
                    existingBranch.IsActive = branch.IsActive;
                    existingBranch.NoOfFPS = branch.NoOfFPS;
                    existingBranch.QtrMonth1 = branch.QtrMonth1;
                    existingBranch.QtrMonth2 = branch.QtrMonth2;
                    existingBranch.QtrMonth3 = branch.QtrMonth3;
                    dbContext.Entry(existingBranch).State = EntityState.Modified;
                }
                else
                {
                    if (branch.PK_MstrBranches == null)
                        branch.PK_MstrBranches = Guid.NewGuid();

                    dbContext.Entry(branch).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return branch;
            }
        }

        public void DeleteBranchByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MstrBranches branch = (from c in dbContext.MstrBranches
                                    where c.PK_MstrBranches == id
                                    select c).FirstOrDefault();

                if (branch != null)
                {
                    dbContext.Entry(branch).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region Dealer

        public ICollection<MstrDealer> GetAllDealer()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrDealer
                        select c).ToList();
            }
        }

        public MstrDealer GetDealerByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrDealer
                        where c.PK_MstrDealer == id
                        select c).FirstOrDefault();
            }
        }

        public MstrDealer SaveDealer(MstrDealer dealer)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingDealer = (from c in dbContext.MstrDealer
                                      where c.PK_MstrDealer == dealer.PK_MstrDealer
                                      select c).FirstOrDefault();

                if (existingDealer != null)
                {
                    existingDealer.Address = dealer.Address;
                    existingDealer.DealerName = dealer.DealerName;
                    existingDealer.FK_MscIncentiveClass = dealer.FK_MscIncentiveClass;
                    existingDealer.FK_MstrAgency = dealer.FK_MstrAgency;
                    existingDealer.IsActive = dealer.IsActive;
                    dbContext.Entry(existingDealer).State = EntityState.Modified;
                }
                else
                {
                    if (dealer.PK_MstrDealer == null)
                        dealer.PK_MstrDealer = Guid.NewGuid();

                    dbContext.Entry(dealer).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return dealer;
            }
        }

        public void DeleteDealerByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MstrDealer dealer = (from c in dbContext.MstrDealer
                                       where c.PK_MstrDealer == id
                                       select c).FirstOrDefault();

                if (dealer != null)
                {
                    dbContext.Entry(dealer).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region FPS Promodizer

        public ICollection<MstrFPS> GetAllFPS()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrFPS
                        select c).ToList();
            }
        }

        public MstrFPS GetFPSByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrFPS
                        where c.PK_MstrFPS == id
                        select c).FirstOrDefault();
            }
        }

        public MstrFPS SaveFPS(MstrFPS fps)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingFPS = (from c in dbContext.MstrFPS
                                      where c.PK_MstrFPS == fps.PK_MstrFPS
                                      select c).FirstOrDefault();

                if (existingFPS != null)
                {
                    existingFPS.FK_MstrAgency = fps.FK_MstrAgency;
                    existingFPS.FK_MstrBranches = fps.FK_MstrBranches;
                    existingFPS.FK_MstrDealer = fps.FK_MstrDealer;
                    existingFPS.FPSName = fps.FPSName;
                    existingFPS.FPSNumber = fps.FPSNumber;
                    existingFPS.IsActive = fps.IsActive;
                    existingFPS.StoreClassification = fps.StoreClassification;
                    dbContext.Entry(existingFPS).State = EntityState.Modified;
                }
                else
                {
                    if (fps.PK_MstrFPS == null)
                        fps.PK_MstrFPS = Guid.NewGuid();

                    dbContext.Entry(fps).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return fps;
            }
        }

        public void DeleteFPSByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MstrFPS fps = (from c in dbContext.MstrFPS
                                     where c.PK_MstrFPS == id
                                     select c).FirstOrDefault();

                if (fps != null)
                {
                    dbContext.Entry(fps).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }

        }

        #endregion

        #region Items

        public ICollection<MstrItems> GetAllItems()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrItems
                        select c).ToList();
            }
        }

        public MstrItems GetItemsByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrItems
                        where c.PK_MstrItems == id
                        select c).FirstOrDefault();
            }
        }

        public MstrItems SaveItems(MstrItems items)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingItems = (from c in dbContext.MstrItems
                                   where c.PK_MstrItems == items.PK_MstrItems
                                   select c).FirstOrDefault();

                if (existingItems != null)
                {
                    existingItems.AutoPerUnitIncentive = items.AutoPerUnitIncentive;
                    existingItems.FK_MscItemCategory = items.FK_MscItemCategory;
                    existingItems.FK_MscSubClassification = items.FK_MscSubClassification;
                    existingItems.FK_MstrDealer = items.FK_MstrDealer;
                    existingItems.IncrePerUnitIncentive = items.IncrePerUnitIncentive;
                    existingItems.IsActive = items.IsActive;
                    existingItems.ItemCode = items.ItemCode;
                    existingItems.ItemDescription = items.ItemDescription;
                    existingItems.Model = items.Model;
                    existingItems.SerialNo = items.SerialNo;
                    existingItems.SRP = items.SRP;
                    existingItems.TargetPerUnitIncentive = items.TargetPerUnitIncentive;
                    existingItems.TargetQty = items.TargetQty;
                    dbContext.Entry(existingItems).State = EntityState.Modified;
                }
                else
                {
                    if (items.PK_MstrItems == null)
                        items.PK_MstrItems = Guid.NewGuid();

                    dbContext.Entry(items).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return items;
            }
        }

        public void DeleteItemsByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MstrItems items = (from c in dbContext.MstrItems
                               where c.PK_MstrItems == id
                               select c).FirstOrDefault();

                if (items != null)
                {
                    dbContext.Entry(items).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region Modules

        public ICollection<MstrModules> GetAllModules()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrModules
                        select c).ToList();
            }
        }

        public MstrModules GetModuleByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MstrModules
                        where c.PK_MstrModules == id
                        select c).FirstOrDefault();
            }
        }

        public MstrModules SaveModule(MstrModules module)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingmodule = (from c in dbContext.MstrModules
                                      where c.PK_MstrModules == module.PK_MstrModules
                                      select c).FirstOrDefault();

                if (existingmodule != null)
                {
                    existingmodule.Name = module.Name;
                    existingmodule.WithAdd = module.WithAdd;
                    existingmodule.WithEdit = module.WithEdit;
                    existingmodule.WithDelete = module.WithDelete;
                    existingmodule.WithPost = module.WithPost;
                    existingmodule.WithVoid = module.WithVoid;
                    existingmodule.IsVisible = module.IsVisible;
                    dbContext.Entry(existingmodule).State = EntityState.Modified;
                }
                else
                {
                    if (module.PK_MstrModules == null)
                        module.PK_MstrModules = Guid.NewGuid();

                    dbContext.Entry(module).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return module;
            }
        }

        public void DeleteModuleByID(Guid id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MstrModules module = (from c in dbContext.MstrModules
                                      where c.PK_MstrModules == id
                                      select c).FirstOrDefault();

                if (module != null)
                {
                    dbContext.Entry(module).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region Incentive Class

        public ICollection<MscIncentiveClass> GetAllIncentiveClass()
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MscIncentiveClass
                        select c).ToList();
            }
        }

        public MscIncentiveClass GetIncentiveClassByID(Int32 id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                return (from c in dbContext.MscIncentiveClass
                        where c.PK_MscIncentiveClass == id
                        select c).FirstOrDefault();
            }
        }

        public MscIncentiveClass SaveIncentiveClass(MscIncentiveClass incentiveclass)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                var existingIncentiveClass = (from c in dbContext.MscIncentiveClass
                                      where c.PK_MscIncentiveClass == incentiveclass.PK_MscIncentiveClass
                                      select c).FirstOrDefault();

                if (existingIncentiveClass != null)
                {
                    existingIncentiveClass.IncentiveClass = incentiveclass.IncentiveClass;
                    dbContext.Entry(existingIncentiveClass).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Entry(incentiveclass).State = EntityState.Added;
                }

                dbContext.SaveChanges();
                return incentiveclass;
            }
        }

        public void DeleteIncentiveClassByID(Int32 id)
        {
            using (IMsDBContext dbContext = new IMsDBContext())
            {
                MscIncentiveClass incentiveClass = (from c in dbContext.MscIncentiveClass
                                      where c.PK_MscIncentiveClass == id
                                      select c).FirstOrDefault();

                if (incentiveClass != null)
                {
                    dbContext.Entry(incentiveClass).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion
    }
}
