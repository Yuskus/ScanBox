﻿using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IDocumentRepository : IRepository
    {
        public int AddDocument(DocumentPostDTO documentPostDTO);
        public int PutDocument(DocumentPostDTO documentPutDTO);
        public int DeleteDocument(int documentId);
        public IEnumerable<DocumentGetDTO> GetDocuments();

    }
}
