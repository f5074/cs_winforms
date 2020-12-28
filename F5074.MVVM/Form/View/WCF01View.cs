﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace F5074.UI.Form.View {
    public partial class WCF01View : UserControl {
        public WCF01View()
        {
            InitializeComponent();
            Contract();

        }

        static void Contract()
        {

            // http://taeyo.net/columns/View.aspx?SEQ=347&PSEQ=23&IDX=5
            Uri uri = new Uri("http://localhost:53045/Services/Common/CommonService.svc");
            ServiceEndpoint ep = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(ICommonService)),
                new BasicHttpBinding(),
                new EndpointAddress(uri));

            ChannelFactory<ICommonService> factory = new ChannelFactory<ICommonService>(ep);

            ICommonService proxy = factory.CreateChannel();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("EQP_ID", "17");
            //var result = proxy.SelectDeptList(parameters);

            var results = proxy.SelectDeptList2(parameters);

            (proxy as IDisposable).Dispose();

            //PDAServiceClient client = new PDAServiceClient();
            //client.SelectDeptList(new PDADTO());
            //DataSet result =  client.SelectDeptList(new System.Collections.Generic.Dictionary<object, object>());
            //// 서비스에서 작업을 호출하려면 'client' 변수를 사용하십시오.
            //IList<PDADTO> result = client.SelectDeptList(new PDADTO());
            //// 항상 클라이언트를 닫으십시오.
            //client.Close();


            //PDAServiceClient client = new PDAServiceClient();

            //Dictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("EQP_ID", "17");

            //var result = client.SelectDeptList2(parameters);

        }
    }

    [ServiceContract]
    public interface ICommonService {

        [OperationContract]
        IList<Hashtable> SelectDeptList(Dictionary<string, object> parameters);

        [OperationContract]
        ApiResponse<IList<Hashtable>> SelectDeptList2(Dictionary<string, object> parameters);
    }



    [DataContract]
    public class ApiResponse<T> {

        [DataMember]
        public bool Result = false;
        [DataMember]
        public T Data;
        [DataMember]
        public string Message = string.Empty;
    }
}
