using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public user Login(string username, string password)
        {
            using (var context = new VaccineEntities())
            {
                var user = context.users.FirstOrDefault(u => u.username == username && u.password == password);
                return user;
            }
        }
        public List<user> GetUsers()
        {
            using (var context = new VaccineEntities())
            {
                return context.users.ToList();
            }
        }

        public user GetUserById(int userId)
        {
            using (var context = new VaccineEntities())
            {
                return context.users.FirstOrDefault(u => u.id == userId);
            }
        }

        public void AddUser(user user)
        {
            using (var context = new VaccineEntities())
            {
                context.users.Add(user);
                context.SaveChanges();
            }
        }

        public void UpdateUser(user user)
        {
            using (var context = new VaccineEntities())
            {
                var existingUser = context.users.FirstOrDefault(u => u.id == user.id);
                if (existingUser != null)
                {
                    existingUser.email = user.email;
                    existingUser.username = user.username;
                    existingUser.password = user.password;
                    existingUser.roles = user.roles;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var context = new VaccineEntities())
            {
                var user = context.users.FirstOrDefault(u => u.id == userId);
                if (user != null)
                {
                    context.users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        /*Hospital*/
        public List<hospital> GetHospitals()
        {
            using (var context = new VaccineEntities())
            {
                return context.hospitals.ToList();
            }
        }

        public hospital GetHospitalById(int hospitalId)
        {
            using (var context = new VaccineEntities())
            {
                return context.hospitals.FirstOrDefault(h => h.id == hospitalId);
            }
        }

        public void AddHospital(hospital hospital)
        {
            using (var context = new VaccineEntities())
            {
                context.hospitals.Add(hospital);
                context.SaveChanges();
            }
        }

        public void UpdateHospital(hospital hospital)
        {
            using (var context = new VaccineEntities())
            {
                var existingHospital = context.hospitals.FirstOrDefault(h => h.id == hospital.id);
                if (existingHospital != null)
                {
                    existingHospital.hospital_name = hospital.hospital_name;
                    existingHospital.address = hospital.address;
                    existingHospital.city = hospital.city;
                    existingHospital.province = hospital.province;
                    existingHospital.country = hospital.country;
                    existingHospital.phone_number = hospital.phone_number;
                    existingHospital.email = hospital.email;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteHospital(int hospitalId)
        {
            using (var context = new VaccineEntities())
            {
                var hospital = context.hospitals.FirstOrDefault(h => h.id == hospitalId);
                if (hospital != null)
                {
                    context.hospitals.Remove(hospital);
                    context.SaveChanges();
                }
            }
        }

        /*Vaccine*/
        public List<vaccine> GetVaccines()
        {
            using (var context = new VaccineEntities())
            {
                return context.vaccines.ToList();
            }
        }

        public vaccine GetVaccineById(int vaccineId)
        {
            using (var context = new VaccineEntities())
            {
                return context.vaccines.FirstOrDefault(v => v.id == vaccineId);
            }
        }

        public void AddVaccine(vaccine vaccine)
        {
            using (var context = new VaccineEntities())
            {
                context.vaccines.Add(vaccine);
                context.SaveChanges();
            }
        }

        public void UpdateVaccine(vaccine vaccine)
        {
            using (var context = new VaccineEntities())
            {
                var existingVaccine = context.vaccines.FirstOrDefault(v => v.id == vaccine.id);
                if (existingVaccine != null)
                {
                    existingVaccine.vaccine_name = vaccine.vaccine_name;
                    existingVaccine.vaccine_type = vaccine.vaccine_type;
                    existingVaccine.dose_count = vaccine.dose_count;
                    existingVaccine.dose = vaccine.dose;
                    existingVaccine.price = vaccine.price;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteVaccine(int vaccineId)
        {
            using (var context = new VaccineEntities())
            {
                var vaccine = context.vaccines.FirstOrDefault(v => v.id == vaccineId);
                if (vaccine != null)
                {
                    context.vaccines.Remove(vaccine);
                    context.SaveChanges();
                }
            }
        }

        /*Community*/
        public List<community> GetCommunities()
        {
            using (var context = new VaccineEntities())
            {
                return context.communities.ToList();
            }
        }

        public community GetCommunityById(int communityId)
        {
            using (var context = new VaccineEntities())
            {
                return context.communities.FirstOrDefault(c => c.id == communityId);
            }
        }

        public void AddCommunity(community community)
        {
            using (var context = new VaccineEntities())
            {
                context.communities.Add(community);
                context.SaveChanges();
            }
        }

        public void UpdateCommunity(community community)
        {
            using (var context = new VaccineEntities())
            {
                var existingCommunity = context.communities.FirstOrDefault(c => c.id == community.id);
                if (existingCommunity != null)
                {
                    existingCommunity.nik = community.nik;
                    existingCommunity.name = community.name;
                    existingCommunity.date_of_birth = community.date_of_birth;
                    existingCommunity.address = community.address;
                    existingCommunity.city = community.city;
                    existingCommunity.province = community.province;
                    existingCommunity.country = community.country;
                    existingCommunity.phone_number = community.phone_number;
                    existingCommunity.email = community.email;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteCommunity(int communityId)
        {
            using (var context = new VaccineEntities())
            {
                var community = context.communities.FirstOrDefault(c => c.id == communityId);
                if (community != null)
                {
                    context.communities.Remove(community);
                    context.SaveChanges();
                }
            }
        }

        /*Vaccine Record*/
        public List<vaccine_records> GetVaccineRecords()
        {
            using (var context = new VaccineEntities())
            {
                return context.vaccine_records.ToList();
            }
        }

        public vaccine_records GetVaccineRecordById(int vaccineRecordId)
        {
            using (var context = new VaccineEntities())
            {
                return context.vaccine_records.FirstOrDefault(vr => vr.id == vaccineRecordId);
            }
        }

        public void AddVaccineRecord(vaccine_records vaccineRecord)
        {
            using (var context = new VaccineEntities())
            {
                context.vaccine_records.Add(vaccineRecord);
                context.SaveChanges();
            }
        }

        public void UpdateVaccineRecord(vaccine_records vaccineRecord)
        {
            using (var context = new VaccineEntities())
            {
                var existingVaccineRecord = context.vaccine_records.FirstOrDefault(vr => vr.id == vaccineRecord.id);
                if (existingVaccineRecord != null)
                {
                    existingVaccineRecord.community_id = vaccineRecord.community_id;
                    existingVaccineRecord.hospital_id = vaccineRecord.hospital_id;
                    existingVaccineRecord.vaccine_id = vaccineRecord.vaccine_id;
                    existingVaccineRecord.vaccine_date = vaccineRecord.vaccine_date;
                    existingVaccineRecord.dose_number = vaccineRecord.dose_number;
                    existingVaccineRecord.administration_type = vaccineRecord.administration_type;
                    existingVaccineRecord.nurse_name = vaccineRecord.nurse_name;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteVaccineRecord(int vaccineRecordId)
        {
            using (var context = new VaccineEntities())
            {
                var vaccineRecord = context.vaccine_records.FirstOrDefault(vr => vr.id == vaccineRecordId);
                if (vaccineRecord != null)
                {
                    context.vaccine_records.Remove(vaccineRecord);
                    context.SaveChanges();
                }
            }
        }

        /*Vaccine Producers*/
        public List<vaccine_producers> GetVaccineProducers()
        {
            using (var context = new VaccineEntities())
            {
                return context.vaccine_producers.ToList();
            }
        }

        public vaccine_producers GetVaccineProducerById(int vaccineProducerId)
        {
            using (var context = new VaccineEntities())
            {
                return context.vaccine_producers.FirstOrDefault(vp => vp.id == vaccineProducerId);
            }
        }

        public void AddVaccineProducer(vaccine_producers vaccineProducer)
        {
            using (var context = new VaccineEntities())
            {
                context.vaccine_producers.Add(vaccineProducer);
                context.SaveChanges();
            }
        }

        public void UpdateVaccineProducer(vaccine_producers vaccineProducer)
        {
            using (var context = new VaccineEntities())
            {
                var existingVaccineProducer = context.vaccine_producers.FirstOrDefault(vp => vp.id == vaccineProducer.id);
                if (existingVaccineProducer != null)
                {
                    existingVaccineProducer.producer_id = vaccineProducer.producer_id;
                    existingVaccineProducer.vaccine_id = vaccineProducer.vaccine_id;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteVaccineProducer(int vaccineProducerId)
        {
            using (var context = new VaccineEntities())
            {
                var vaccineProducer = context.vaccine_producers.FirstOrDefault(vp => vp.id == vaccineProducerId);
                if (vaccineProducer != null)
                {
                    context.vaccine_producers.Remove(vaccineProducer);
                    context.SaveChanges();
                }
            }
        }

        /*Producer*/
        public List<producer> GetProducers()
        {
            using (var context = new VaccineEntities())
            {
                return context.producers.ToList();
            }
        }

        public producer GetProducerById(int producerId)
        {
            using (var context = new VaccineEntities())
            {
                return context.producers.FirstOrDefault(p => p.id == producerId);
            }
        }

        public void AddProducer(producer producer)
        {
            using (var context = new VaccineEntities())
            {
                context.producers.Add(producer);
                context.SaveChanges();
            }
        }

        public void UpdateProducer(producer producer)
        {
            using (var context = new VaccineEntities())
            {
                var existingProducer = context.producers.FirstOrDefault(p => p.id == producer.id);
                if (existingProducer != null)
                {
                    existingProducer.producer_name = producer.producer_name;
                    existingProducer.address = producer.address;
                    existingProducer.city = producer.city;
                    existingProducer.province = producer.province;
                    existingProducer.country = producer.country;
                    existingProducer.phone_number = producer.phone_number;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProducer(int producerId)
        {
            using (var context = new VaccineEntities())
            {
                var producer = context.producers.FirstOrDefault(p => p.id == producerId);
                if (producer != null)
                {
                    context.producers.Remove(producer);
                    context.SaveChanges();
                }
            }
        }


    }
}
