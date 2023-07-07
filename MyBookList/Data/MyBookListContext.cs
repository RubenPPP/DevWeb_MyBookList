using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookList.Models;

namespace MyBookList.Data
{
    public class MyBookListContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasKey(s => new { s.MemberFK, s.BookFK });

            Seed(modelBuilder);
        }
        protected void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>().HasData(
                new Authors { Id = 1, Name = "Cherie Priest", Biography = "Cherie Priest is the author of two dozen books and novellas, most recently The Toll, The Family Plot, The Agony House, and the Philip K. Dick Award nominee Maplecroft; but she is perhaps best known for the steampunk pulp adventures of the Clockwork Century, beginning with Boneshaker. Her works have been nominated for the Hugo and Nebula awards for science fiction, and have won the Locus Award (among others) – and over the years, they’ve been translated into nine languages in eleven countries. Cherie lives in Seattle, WA, with her husband and a menagerie of exceedingly photogenic pets." },
                new Authors { Id = 2, Name = "Tim Powers", Biography = "Timothy Thomas Powers is an American science fiction and fantasy author. Powers has won the World Fantasy Award twice for his critically acclaimed novels Last Call and Declare.\r\n\r\nMost of Powers's novels are \"secret histories\": he uses actual, documented historical events featuring famous people, but shows another view of them in which occult or supernatural factors heavily influence the motivations and actions of the characters.\r\n\r\n\r\nPowers was born in Buffalo, New York, and grew up in California, where his Roman Catholic family moved in 1959.\r\n\r\nHe studied English Literature at Cal State Fullerton, where he first met James Blaylock and K.W. Jeter, both of whom remained close friends and occasional collaborators; the trio have half-seriously referred to themselves as \"steampunks\" in contrast to the prevailing cyberpunk genre of the 1980s. Powers and Blaylock invented the poet William Ashbless while they were at Cal State Fullerton.\r\n\r\nAnother friend Powers first met during this period was noted science fiction writer Philip K. Dick; the character named \"David\" in Dick's novel VALIS is based on Powers and Do Androids Dream of Electric Sheep? (Blade Runner) is dedicated to him.\r\n\r\nPowers's first major novel was The Drawing of the Dark (1979), but the novel that earned him wide praise was The Anubis Gates, which won the Philip K. Dick Award, and has since been published in many other languages.\r\n\r\nPowers also teaches part-time in his role as Writer in Residence for the Orange County High School of the Arts where his friend, Blaylock, is Director of the Creative Writing Department. Powers and his wife, Serena, currently live in Muscoy, California. He has frequently served as a mentor author as part of the Clarion science fiction/fantasy writer's workshop.\r\n\r\nHe also taught part time at the University of Redlands." },
                new Authors { Id = 3, Name = "Alden Bell", Biography = "Alden Bell is a pseudonym for Joshua Gaylord, whose first novel, Hummingbirds, was released in Fall '09. He teaches at a New York City prep school and is an adjunct professor at The New School. He lives in New York City with his wife, the Edgar Award-winning mystery writer, Megan Abbott." }
            );

            modelBuilder.Entity<Publishers>().HasData(
                new Publishers { Id = 1, Name = "Tor Books", Description = "Tor Books is the primary imprint of Tor Publishing Group (previously Tom Doherty Associates), a publishing company based in New York City. It primarily publishes science fiction and fantasy titles." },
                new Publishers { Id = 2, Name = "Ace Books", Description = "Ace Books is a publisher of science fiction and fantasy books founded in New York City in 1952 by Aaron A. Wyn. It began as a genre publisher of mysteries and westerns, and soon branched out into other genres, publishing its first science fiction title in 1953." },
                new Publishers { Id = 3, Name = "Holt Paperbacks", Description = "Holt Paperbacks publishes reprints from all the company’s adult imprints including Henry Holt, Metropolitan Books, and Times Books. Holt Paperbacks also publishes original trade paperbacks across all the categories that Henry Holt focuses on, including literary fiction, mysteries and thrillers, history, current events, social science, adventure, biography and memoir, personal development, and psychology. Whether as an original or reprint, every book on the Holt Paperbacks list strives to deliver to the paperback reader the same high caliber of information and entertainment that is the hallmark of all Henry Holt publications. Acclaimed and bestselling authors published under the Holt Paperbacks imprint include Rick Atkinson, Noam Chomsky, Barbara Ehrenreich, Harville Hendrix, Julie Morgenstern, and Stacy Schiff." },
                new Publishers { Id = 4, Name = "Babbage Press", Description = "Test"}
            );

            modelBuilder.Entity<Genres>().HasData(
                new Genres { Id = 1, Genre = "Science Fiction" },
                new Genres { Id = 2, Genre = "Fantasy" },
                new Genres { Id = 3, Genre = "Horror" },
                new Genres { Id = 4, Genre = "Adventure" },
                new Genres { Id = 5, Genre = "Fiction" },
                new Genres { Id = 6, Genre = "Paranormal" },
                new Genres { Id = 7, Genre = "Mystery" },
                new Genres { Id = 8, Genre = "Historical" },
                new Genres { Id = 9, Genre = "Apocalyptic" }
            );
            /*
            modelBuilder.Entity<Books>().HasData(
                new Books { ISBN = "9780765318411", Title = "Boneshaker", GenresList = new List<Genres> { Genres.Find(1), Genres.Find(2), Genres.Find(3), Genres.Find(4) }, PublisherFK = 1, Publisher = Publishers.Find(1), Score = 0, AuthorsList = new List<Authors> { Authors.Find(1) }, Description = "In the early days of the Civil War, rumors of gold in the frozen Klondike brought hordes of newcomers to the Pacific Northwest. Anxious to compete, Russian prospectors commissioned inventor Leviticus Blue to create a great machine that could mine through Alaska’s ice. Thus was Dr. Blue’s Incredible Bone-Shaking Drill Engine born.\r\n\r\nBut on its first test run the Boneshaker went terribly awry, destroying several blocks of downtown Seattle and unearthing a subterranean vein of blight gas that turned anyone who breathed it into the living dead.\r\n\r\nNow it is sixteen years later, and a wall has been built to enclose the devastated and toxic city. Just beyond it lives Blue’s widow, Briar Wilkes. Life is hard with a ruined reputation and a teenaged boy to support, but she and Ezekiel are managing. Until Ezekiel undertakes a secret crusade to rewrite history.\r\n\r\nHis quest will take him under the wall and into a city teeming with ravenous undead, air pirates, criminal overlords, and heavily armed refugees. And only Briar can bring him out alive." },
                new Books { ISBN = "9780765378248", Title = "The Family Plot", GenresList = new List<Genres> { Genres.Find(3), Genres.Find(5), Genres.Find(6), Genres.Find(7) }, PublisherFK = 1, Publisher = Publishers.Find(1), Score = 0, AuthorsList = new List<Authors> { Authors.Find(1) }, Description = "Music City Salvage is a family operation, owned and operated by Chuck Dutton: master stripper of doomed historic properties, and expert seller of all things old and crusty. But business is lean and times are tight, so he’s thrilled when the aged and esteemed Augusta Withrow appears in his office, bearing an offer he really ought to refuse. She has a massive family estate to unload - lock, stock, and barrel. For a check and a handshake, it’s all his.\r\n\r\nIt’s a big check. It’s a firm handshake. And it’s enough of a gold mine that he assigns his daughter Dahlia to personally oversee the project.\r\n\r\nDahlia preps a couple of trucks, takes a small crew, and they caravan down to Chattanooga, Tennessee, where the ancient Withrow house is waiting - and so is a barn, a carriage house, and a small, overgrown cemetery that Augusta Withrow left out of the paperwork.\r\n\r\nAugusta Withrow left out a lot of things.\r\n\r\nThe property is in unusually great shape for a condemned building. It’s empty, but it isn't abandoned. Something in the Withrow mansion is angry and lost. This is its last chance to raise hell before the house is gone forever, and there's still plenty of room in the strange little family plot.\r\n\r\nNew from Cherie Priest, a modern master of supernatural fiction, The Family Plot is a haunted house story for the ages - atmospheric, scary, and strange, with a modern gothic sensibility that every bit as fresh as it is frightening." },
                new Books { ISBN = "9780441004010", Title = "The Anubis Gates", GenresList = new List<Genres> { Genres.Find(2), Genres.Find(1), Genres.Find(8) }, PublisherFK = 2, Publisher = Publishers.Find(2), Score = 0, AuthorsList = new List<Authors> { Authors.Find(2) }, Description = "Brendan Doyle, a specialist in the work of the early-nineteenth century poet William Ashbless, reluctantly accepts an invitation from a millionaire to act as a guide to time-travelling tourists. But while attending a lecture given by Samuel Taylor Coleridge in 1810, he becomes marooned in Regency London, where dark and dangerous forces know about the gates in time.\r\n\r\nCaught up in the intrigue between rival bands of beggars, pursued by Egyptian sorcerers, and befriended by Coleridge, Doyle somehow survives and learns more about the mysterious Ashbless than he could ever have imagined possible..." },
                new Books { ISBN = "9781930235328", Title = "On Stranger Tides", GenresList = new List<Genres> { Genres.Find(2), Genres.Find(4), Genres.Find(3) }, PublisherFK = 4, Publisher = Publishers.Find(4), Score = 0, AuthorsList = new List<Authors> { Authors.Find(2) }, Description = "Aboard the Vociferous Carmichael, puppeteer John Chandagnac is sailing toward Jamaica to claim his stolen birthright from an unscrupulous uncle, when the vessel is captured . . . by pirates! Offered a choice by Captain Phil Davies to join their seafaring band or die, Chandagnac assumes the name John Shandy and a new life as a brigand. But more than swashbuckling sea battles and fabulous plunder await the novice buccaneer on the roiling Caribbean waters–for treachery and powerful vodun sorcery are coins of the realm in this dark new world. And for the love of beautiful, magically imperiled Beth Hurwood, Shandy will set sail on even stranger tides, following the savage, ghost-infested pirate king, Blackbeard, and a motley crew of the living and the dead to the cursed nightmare banks of the fabled Fountain of Youth." },
                new Books { ISBN = "9780805092431", Title = "The Reapers are the Angels", GenresList = new List<Genres> { Genres.Find(3), Genres.Find(9), Genres.Find(1), Genres.Find(2) }, PublisherFK = 3, Publisher = Publishers.Find(3), Score = 0, AuthorsList = new List<Authors> { Authors.Find(3) }, Description = "Zombies have infested a fallen America. A young girl named Temple is on the run. Haunted by her past and pursued by a killer, Temple is surrounded by death and danger, hoping to be set free.\r\n\r\nFor twenty-five years, civilization has survived in meager enclaves, guarded against a plague of the dead. Temple wanders this blighted landscape, keeping to herself - and keeping her demons inside. She can't remember a time before the zombies, but she does remember an old man who took her in and the younger brother she cared for until the tragedy that set her on a personal journey toward redemption. Moving back and forth between the insulated remnants of society and the brutal frontier beyond, Temple must decide where ultimately to make a home and find the salvation she seeks." }
                
            );
            */
        }

        public MyBookListContext (DbContextOptions<MyBookListContext> options)
            : base(options)
        {
        }

        public DbSet<MyBookList.Models.Genres> Genres { get; set; } = default!;

        public DbSet<MyBookList.Models.Status>? Status { get; set; }

        public DbSet<MyBookList.Models.Authors>? Authors { get; set; }

        public DbSet<MyBookList.Models.Publishers>? Publishers { get; set; }

        public DbSet<MyBookList.Models.Books>? Books { get; set; }

        public DbSet<MyBookList.Models.Members>? Members { get; set; }
    }
}
