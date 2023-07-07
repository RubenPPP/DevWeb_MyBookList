using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookList.Data.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Name" },
                values: new object[,]
                {
                    { 1, "Cherie Priest is the author of two dozen books and novellas, most recently The Toll, The Family Plot, The Agony House, and the Philip K. Dick Award nominee Maplecroft; but she is perhaps best known for the steampunk pulp adventures of the Clockwork Century, beginning with Boneshaker. Her works have been nominated for the Hugo and Nebula awards for science fiction, and have won the Locus Award (among others) – and over the years, they’ve been translated into nine languages in eleven countries. Cherie lives in Seattle, WA, with her husband and a menagerie of exceedingly photogenic pets.", "Cherie Priest" },
                    { 2, "Timothy Thomas Powers is an American science fiction and fantasy author. Powers has won the World Fantasy Award twice for his critically acclaimed novels Last Call and Declare.\r\n\r\nMost of Powers's novels are \"secret histories\": he uses actual, documented historical events featuring famous people, but shows another view of them in which occult or supernatural factors heavily influence the motivations and actions of the characters.\r\n\r\n\r\nPowers was born in Buffalo, New York, and grew up in California, where his Roman Catholic family moved in 1959.\r\n\r\nHe studied English Literature at Cal State Fullerton, where he first met James Blaylock and K.W. Jeter, both of whom remained close friends and occasional collaborators; the trio have half-seriously referred to themselves as \"steampunks\" in contrast to the prevailing cyberpunk genre of the 1980s. Powers and Blaylock invented the poet William Ashbless while they were at Cal State Fullerton.\r\n\r\nAnother friend Powers first met during this period was noted science fiction writer Philip K. Dick; the character named \"David\" in Dick's novel VALIS is based on Powers and Do Androids Dream of Electric Sheep? (Blade Runner) is dedicated to him.\r\n\r\nPowers's first major novel was The Drawing of the Dark (1979), but the novel that earned him wide praise was The Anubis Gates, which won the Philip K. Dick Award, and has since been published in many other languages.\r\n\r\nPowers also teaches part-time in his role as Writer in Residence for the Orange County High School of the Arts where his friend, Blaylock, is Director of the Creative Writing Department. Powers and his wife, Serena, currently live in Muscoy, California. He has frequently served as a mentor author as part of the Clarion science fiction/fantasy writer's workshop.\r\n\r\nHe also taught part time at the University of Redlands.", "Tim Powers" },
                    { 3, "Alden Bell is a pseudonym for Joshua Gaylord, whose first novel, Hummingbirds, was released in Fall '09. He teaches at a New York City prep school and is an adjunct professor at The New School. He lives in New York City with his wife, the Edgar Award-winning mystery writer, Megan Abbott.", "Alden Bell" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "Science Fiction" },
                    { 2, "Fantasy" },
                    { 3, "Horror" },
                    { 4, "Adventure" },
                    { 5, "Fiction" },
                    { 6, "Paranormal" },
                    { 7, "Mystery" },
                    { 8, "Historical" },
                    { 9, "Apocalyptic" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Tor Books is the primary imprint of Tor Publishing Group (previously Tom Doherty Associates), a publishing company based in New York City. It primarily publishes science fiction and fantasy titles.", "Tor Books" },
                    { 2, "Ace Books is a publisher of science fiction and fantasy books founded in New York City in 1952 by Aaron A. Wyn. It began as a genre publisher of mysteries and westerns, and soon branched out into other genres, publishing its first science fiction title in 1953.", "Ace Books" },
                    { 3, "Holt Paperbacks publishes reprints from all the company’s adult imprints including Henry Holt, Metropolitan Books, and Times Books. Holt Paperbacks also publishes original trade paperbacks across all the categories that Henry Holt focuses on, including literary fiction, mysteries and thrillers, history, current events, social science, adventure, biography and memoir, personal development, and psychology. Whether as an original or reprint, every book on the Holt Paperbacks list strives to deliver to the paperback reader the same high caliber of information and entertainment that is the hallmark of all Henry Holt publications. Acclaimed and bestselling authors published under the Holt Paperbacks imprint include Rick Atkinson, Noam Chomsky, Barbara Ehrenreich, Harville Hendrix, Julie Morgenstern, and Stacy Schiff.", "Holt Paperbacks" },
                    { 4, "Test", "Babbage Press" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
