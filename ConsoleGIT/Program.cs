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
    class Program
    {
        public static string path;
        public static string fromDate = "01/01/2017";
        public static string toDate = "21/01/2017";

      
        static DateTime fromdt = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
        static DateTime todt = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
        static string path = @"D:\GITSource\LibGit2Sharp5";
       

        public static void Main(string[] args)
        {
            Console.Clear();
            
            try
            {
             var co = new CloneOptions();
           
            co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = "mbandari", Password = "Jjong@310711" };
            
            co.IsBare = true;
           
            string  Mainpath =  Repository.Clone("https://github.com/photonstorm/phaser.git.", path, co);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail GIT");               
            }
            using (var Git = new Repository(path))
            {
                // No of commits
                foreach (var Commit in Git.Commits)
                {
                    //foreach (var branch in Git.Branches)
                    //{
                    //    Console.WriteLine(branch.RemoteName);
                    //}

                    // Changes in each commit
                    foreach (var parent in Commit.Parents)
                    {
                        if (Commit.Committer.When.DateTime > fromdt && Commit.Committer.When.DateTime < todt)
                        {
                            Console.WriteLine("{0} | {1}", Commit.Sha, Commit.MessageShort);
                            foreach (TreeEntryChanges change in Git.Diff.Compare<TreeChanges>(parent.Tree, Commit.Tree))
                            {
                                Console.WriteLine("{0} : {1}", change.Status, change.Path);
                            }
                            Console.WriteLine("{0} by {1}",
                                    Commit.Committer.When.DateTime,
                                    Commit.Id.ToString(7),
                                    Commit.Author.Name);

                        }
                        
                    }
                }
            }
            
            Console.WriteLine("Success GIT");
          
        }

    }
       
}
