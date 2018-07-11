using DPAWaiver.Models;
using DPAWaiver.Models.WaiverSelection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPAWaiver.Data
{
    public class DbInitializer
    {
        WaiverDBContext _context;
        ILOVPopulator _populator;

        public DbInitializer(WaiverDBContext context, ILOVPopulator populator)
        {
            _context = context;
            _populator = populator;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();
            SavePurposes();
            SavePurposeTypes();
            SavePurposeSubtypes();
            Console.WriteLine("DB Created: ");

        }

        public void SavePurposeTypes()
        {
            SaveServiceTypes();
            SavePersonnelServiceTypes();
            SaveEquipmentTypes();
            SaveSoftwareTypes();
        }

        public void SavePurposes()
        {

            var purposes = _populator.getPurposes();
            var savedPurposes = _context.Purposes;
            DBInitializeHelper.MergePurposes(savedPurposes, purposes);
            _context.SaveChanges();
        }

        public void SavePurposeSubtypes()
        {
            SaveMicrofilmSubtypes();
            SavePrinterSubtypes();
        }
        public void SaveMicrofilmSubtypes()
        {

            var newPurposeSubtypes = _populator.getMicrofilmSubtypes();
            MergePurposeSubtypes(newPurposeSubtypes, 5);
        }
        public void SavePrinterSubtypes()
        {

            var newPurposeSubtypes = _populator.getPrinterSubtypes();
            MergePurposeSubtypes(newPurposeSubtypes, 11);
        }


        public void SaveServiceTypes()
        {

            var newPurposeTypes = _populator.getServiceTypes();
            MergePurposeTypes(newPurposeTypes, 1);
        }

        public void SavePersonnelServiceTypes()
        {

            var newPurposeTypes = _populator.getPersonnelServiceTypes();
            MergePurposeTypes(newPurposeTypes, 2);
        }

        public void SaveEquipmentTypes()
        {

            var newPurposeTypes = _populator.getEquipmentTypes();
            MergePurposeTypes(newPurposeTypes, 3);
        }

        public void SaveSoftwareTypes()
        {
            var newPurposeTypes = _populator.getSoftwareTypes();
            MergePurposeTypes(newPurposeTypes, 4);
        }

        private void MergePurposeTypes(List<PurposeType> newPurposeTypes, int purposeId)
        {
            var savedPurposeTypes = _context.PurposeTypes.Where(x => x.purpose.ID == purposeId);
            var relatedPurpose = _context.Purposes.Single(x => x.ID == purposeId);
            var newList = DBInitializeHelper.MergePurposeTypes(savedPurposeTypes, newPurposeTypes);
            foreach (var item in newList)
            {
                item.purpose = relatedPurpose;
                _context.PurposeTypes.Add(item);
            }
            _context.SaveChanges();
        }

        private void MergePurposeSubtypes(List<PurposeSubtype> newPurposeTypes, int purposeTypeId)
        {
            var savedPurposeTypes = _context.PurposeSubtypes.Where(x => x.purposeType.ID == purposeTypeId);
            var relatedPurposeType = _context.PurposeTypes.Single(x => x.ID == purposeTypeId);
            var newList = DBInitializeHelper.MergePurposeSubtypes(savedPurposeTypes, newPurposeTypes);
            foreach (var item in newList)
            {
                item.purposeType = relatedPurposeType;
                _context.PurposeSubtypes.Add(item);
            }
            _context.SaveChanges();
        }

    }
}