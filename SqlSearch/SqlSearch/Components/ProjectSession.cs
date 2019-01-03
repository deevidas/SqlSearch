﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caliburn.Micro;
using Cursor = System.Windows.Input.Cursor;

namespace SqlSearch.Components
{
    public class ProjectSession : PropertyChangedBase
    {
        public SqlConnector Connection
        {
            get => _sqlConnector;
            set
            {
                _sqlConnector = value;
                NotifyOfPropertyChange(() => Connection);
            }
        }
        public ConnectionInformation ConnectionInformation { get; set; }
        public SearchCriteria SearchCriteria
        {
            get => _searchCriteria;
            set
            {
                if (_searchCriteria == value) return;
                _searchCriteria = value;
                NotifyOfPropertyChange(() => SearchCriteria);
            }
        }
        public List<SearchResults> SearchResults
        {
            get => _searchResults;
            set
            {
                if (_searchResults == value) return;
                _searchResults = value;
                NotifyOfPropertyChange(() => SearchResults);
            }
        }

        private List<SearchResults> _searchResults;
        private SearchCriteria _searchCriteria;
        private SqlConnector _sqlConnector;

        public ProjectSession()
        {
            Initialization();
        }

        public void Initialization()
        {
            Connection = new SqlConnector();
            ConnectionInformation = new ConnectionInformation();
            SearchCriteria = new SearchCriteria();
            SearchResults = new List<SearchResults>();
        }

        #region Sql connection managing

        public Task<bool> OpenConnection(ConnectionInformation conInfo)
        {
            ConnectionInformation = conInfo;
            var status = Connection.OpenConnection(ConnectionInformation);
            return status;
        }

        public void CloseConnection()
        {
            Connection.CloseConnection();
        }

        #endregion


    }
}
