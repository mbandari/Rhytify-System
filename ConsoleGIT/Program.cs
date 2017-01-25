using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ConsoleGIT
{
   public class Program
    {
        public static string path;
        public static string fromDate = "01/01/2017";
        public static string toDate = "25/01/2017";

      
        static DateTime fromdt = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
        static DateTime todt = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
        public static string RepoPath = @"D:\GITSource\LibGit2Sharp7";

       
      

        public static void Main(string[] args)
        {
            Console.Clear();
            
             //  var co = new CloneOptions();
                CloneOptions co = new CloneOptions();
                string un = "mbandari";
                string pwd = "Jjong@310711";
                Credentials ca = new UsernamePasswordCredentials() { Username = un, Password = pwd };
                co.CredentialsProvider = (_url, _user, _cred) => ca;
                co.IsBare = true;
               if (Directory.Exists(RepoPath))
              {
                using (var repo = new Repository(@"D:\GITSource\LibGit2Sharp7"))
                {
                    foreach (Remote remote in repo.Network.Remotes)
                    {
                        FetchOptions options = new FetchOptions();
                        options.CredentialsProvider = new CredentialsHandler(
                                (url, usernameFromUrl, types) =>
                    new UsernamePasswordCredentials()
                    {
                        Username = un,
                        Password = pwd
                    });
                        repo.Network.Fetch(remote, options);
                    }
                }
            }


            try
            {

                //https://github.com/mbandari/Rhytify-System.git
                //https://github.com/photonstorm/phaser.git
                  string Mainpath =  Repository.Clone("https://github.com/mbandari/Rhytify-System.git", @"D:\GITSource\LibGit2Sharp7", co);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail Clone GIT");

               
            }
            using (var Git = new Repository(@"D:\GITSource\LibGit2Sharp7"))
            {
                // No of commits
                foreach (var Commit in Git.Commits)
                {
                    // Changes in each commit
                    foreach (var parent in Commit.Parents)
                    {
                        // Changes between from-date and to-date
                        if (Commit.Committer.When.DateTime > fromdt && Commit.Committer.When.DateTime < todt)
                        {
                            //Console.WriteLine("{0} | {1}", Commit.Sha, Commit.MessageShort);
                            
                            // Change fileNames
                            foreach (TreeEntryChanges change in Git.Diff.Compare<TreeChanges>(parent.Tree, Commit.Tree))
                            {
                                Console.WriteLine("{0} : {1}", change.Status, change.Path);
                                Console.WriteLine("{0} by {1}",
                                   Commit.Committer.When.DateTime,
                                   Commit.Id.ToString(7),
                                   Commit.Author.Name);
                            }
                           

                        }
                        
                    }
                }
            }
            
            Console.WriteLine("Success GIT");
          
        }

    }
       
}
