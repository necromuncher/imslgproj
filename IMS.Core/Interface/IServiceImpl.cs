using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS.Core.Model;

namespace IMS.Core.Interface
{
    public interface IServiceImpl
    {
        #region AppUsers
        ICollection<AppUsers> GetAllAppUsers();
        AppUsers GetAppUserByID(Guid id);
        AppUsers SaveAppUser(AppUsers user);
        void DeleteAppUserByID(Guid id);
        #endregion

        #region AppUsers Modules
        ICollection<AppUsersModules> GetAllAppUsersModules(Guid userid);
        AppUsersModules GetAppUsersModulesByID(Guid id);
        AppUsersModules SaveAppUsersModules(AppUsersModules userModules);
        void DeleteAppUsersModulesByID(Guid id);
        #endregion

        #region  Agency
        ICollection<MstrAgency> GetAllAgents();
        MstrAgency GetAgentByID(Guid id);
        MstrAgency SaveAgent(MstrAgency agent);
        void DeleteAgentByID(Guid id);
        #endregion

        #region  Modules
        ICollection<MstrModules> GetAllModules();
        MstrModules GetModuleByID(Guid id);
        MstrModules SaveModule(MstrModules module);
        void DeleteModuleByID(Guid id);
        #endregion

        #region  Branches
        ICollection<MstrBranches> GetAllBranches();
        MstrBranches GetBranchByID(Guid id);
        MstrBranches SaveModule(MstrBranches branch);
        void DeleteBranchByID(Guid id);
        #endregion

        #region  Dealers
        ICollection<MstrDealer> GetAllDealer();
        MstrDealer GetDealerByID(Guid id);
        MstrDealer SaveDealer(MstrDealer dealer);
        void DeleteDealerByID(Guid id);
        #endregion

        #region  FPS Promodizer
        ICollection<MstrFPS> GetAllFPS();
        MstrFPS GetFPSByID(Guid id);
        MstrFPS SaveFPS(MstrFPS fps);
        void DeleteFPSByID(Guid id);
        #endregion

        #region  Items
        ICollection<MstrItems> GetAllItems();
        MstrItems GetItemsByID(Guid id);
        MstrItems SaveItems(MstrItems items);
        void DeleteItemsByID(Guid id);
        #endregion

        #region  Item Category
        ICollection<MscItemCategory> GetAllItemCategory();
        MscItemCategory GetItemCategoryByID(Int32 id);
        MscItemCategory SaveItemCategory(MscItemCategory category);
        void DeleteItemCategoryByID(Int32 id);
        #endregion

        #region  Sub Classification
        ICollection<MscSubClassification> GetAllSubClassification();
        MscSubClassification GetSubClassificationByID(Int32 id);
        MscSubClassification SaveSubClassification(MscSubClassification subclass);
        void DeleteSubClassificationByID(Int32 id);
        #endregion

        #region  Incentive Class
        ICollection<MscIncentiveClass> GetAllIncentiveClass();
        MscIncentiveClass GetIncentiveClassByID(Int32 id);
        MscIncentiveClass SaveIncentiveClass(MscIncentiveClass incentiveclass);
        void DeleteIncentiveClassByID(Int32 id);
        #endregion
    }
}
