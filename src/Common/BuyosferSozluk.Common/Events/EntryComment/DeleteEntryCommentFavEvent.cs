using BuyosferSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyosferSozluk.Common.Events.EntryComment;

public class DeleteEntryCommentFavEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid CreatedBy { get; set; }
    }
