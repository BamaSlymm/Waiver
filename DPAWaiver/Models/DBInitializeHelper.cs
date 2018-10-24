using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Models.LOV;
using DPAWaiver.Models.WaiverSelection;
using Microsoft.EntityFrameworkCore;

namespace DPAWaiver.Models
{
    public static class DBInitializeHelper
    {

        public static void MergeBaseLOV(DbSet<BaseLOV> initialList, IEnumerable<BaseLOV> otherList)
        {
            if (!otherList.Any())
            {
                return;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => ((BaseLOV)x).ID == ((BaseLOV)currentElem).ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    initialList.Add(anElem);
                }
            }
        }


        public static void MergeSingleFunctionPrinterPreferences(DbSet<SingleFunctionPrinterPreferences> initialList, IEnumerable<SingleFunctionPrinterPreferences> otherList)
        {
            if (!otherList.Any())
            {
                return;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => ((SingleFunctionPrinterPreferences)x).ID == ((SingleFunctionPrinterPreferences)currentElem).ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    initialList.Add(anElem);
                }
            }
        }

        public static DbSet<Purpose> MergePurposes(DbSet<Purpose> initialList, IEnumerable<Purpose> otherList)
        {
            if (!otherList.Any())
            {
                return initialList;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => ((Purpose)x).ID == ((Purpose)currentElem).ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    initialList.Add(anElem);
                }
            }
            return initialList;
        }

        public static IEnumerable<PurposeType> MergePurposeTypes(IQueryable<PurposeType> initialList, IEnumerable<PurposeType> otherList)
        {
            List<PurposeType> newList = new List<PurposeType>();
            if (!otherList.Any())
            {
                return initialList;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => x.ID == currentElem.ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    newList.Add(anElem);
                }
            }
            return newList;
        }

        public static IEnumerable<PurposeSubtype> MergePurposeSubtypes(IQueryable<PurposeSubtype> initialList, IEnumerable<PurposeSubtype> otherList)
        {
            List<PurposeSubtype> newList = new List<PurposeSubtype>();
            if (!otherList.Any())
            {
                return initialList;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => x.ID == currentElem.ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    newList.Add(anElem);
                }
            }
            return newList;
        }

        public static IEnumerable<MicrofilmOutputType> MergeMicrofilmOutputType(IQueryable<MicrofilmOutputType> initialList, IEnumerable<MicrofilmOutputType> otherList)
        {
            List<MicrofilmOutputType> newList = new List<MicrofilmOutputType>();
            if (!otherList.Any())
            {
                return initialList;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => x.ID == currentElem.ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    newList.Add(anElem);
                }
            }
            return newList;
        }
        public static IEnumerable<DesignType> MergeDesignType(IQueryable<DesignType> initialList, IEnumerable<DesignType> otherList)
        {
            List<DesignType> newList = new List<DesignType>();
            if (!otherList.Any())
            {
                return initialList;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => x.ID == currentElem.ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    newList.Add(anElem);
                }
            }
            return newList;
        }
        public static IEnumerable<Department> MergeDepartment(IQueryable<Department> initialList, IEnumerable<Department> otherList)
        {
            List<Department> newList = new List<Department>();
            if (!otherList.Any())
            {
                return initialList;
            }
            foreach (var currentElem in initialList)
            {
                currentElem.Update(otherList.FirstOrDefault(x => x.ID == currentElem.ID));
            }
            foreach (var anElem in otherList)
            {
                if (!initialList.Any(x => x.ID == anElem.ID))
                {
                    newList.Add(anElem);
                }
            }
            return newList;
        }



    }
}