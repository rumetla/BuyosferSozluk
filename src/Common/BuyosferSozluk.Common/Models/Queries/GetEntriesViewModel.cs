using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyosferSozluk.Common.Models.Queries;

public class GetEntriesViewModel: BaseFooterFavoritedViewModel
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public int CommentCount { get; set; }
}
