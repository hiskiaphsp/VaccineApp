using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /*User Management*/
        [OperationContract]
        user Login(string username, string password);
        [OperationContract]
        List<user> GetUsers();

        [OperationContract]
        user GetUserById(int userId);

        [OperationContract]
        void AddUser(user user);

        [OperationContract]
        void UpdateUser(user user);

        [OperationContract]
        void DeleteUser(int userId);

        /*Management Hospital*/
        [OperationContract]
        List<hospital> GetHospitals();

        [OperationContract]
        hospital GetHospitalById(int hospitalId);

        [OperationContract]
        void AddHospital(hospital hospital);

        [OperationContract]
        void UpdateHospital(hospital hospital);

        [OperationContract]
        void DeleteHospital(int hospitalId);

        /*Vaccine*/
        [OperationContract]
        List<vaccine> GetVaccines();

        [OperationContract]
        vaccine GetVaccineById(int vaccineId);

        [OperationContract]
        void AddVaccine(vaccine vaccine);

        [OperationContract]
        void UpdateVaccine(vaccine vaccine);

        [OperationContract]
        void DeleteVaccine(int vaccineId);

        /*Community*/
        [OperationContract]
        List<community> GetCommunities();

        [OperationContract]
        community GetCommunityById(int communityId);

        [OperationContract]
        void AddCommunity(community community);

        [OperationContract]
        void UpdateCommunity(community community);

        [OperationContract]
        void DeleteCommunity(int communityId);

        /*Vaccine Record*/
        [OperationContract]
        List<vaccine_records> GetVaccineRecords();

        [OperationContract]
        vaccine_records GetVaccineRecordById(int vaccineRecordId);

        [OperationContract]
        void AddVaccineRecord(vaccine_records vaccineRecord);

        [OperationContract]
        void UpdateVaccineRecord(vaccine_records vaccineRecord);

        [OperationContract]
        void DeleteVaccineRecord(int vaccineRecordId);

        /*Vaccine Producers*/
        [OperationContract]
        List<vaccine_producers> GetVaccineProducers();

        [OperationContract]
        vaccine_producers GetVaccineProducerById(int vaccineProducerId);

        [OperationContract]
        void AddVaccineProducer(vaccine_producers vaccineProducer);

        [OperationContract]
        void UpdateVaccineProducer(vaccine_producers vaccineProducer);

        [OperationContract]
        void DeleteVaccineProducer(int vaccineProducerId);

        /*Producers*/
        [OperationContract]
        List<producer> GetProducers();

        [OperationContract]
        producer GetProducerById(int producerId);

        [OperationContract]
        void AddProducer(producer producer);

        [OperationContract]
        void UpdateProducer(producer producer);

        [OperationContract]
        void DeleteProducer(int producerId);


    }
}
