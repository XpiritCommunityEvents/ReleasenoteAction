﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateReleaseNotes.GeneratedClasses
{

    public class Issues
    {
        public Issue[] issues { get; set; }
    }

    public class Issue
    {
        public string url { get; set; }
        public string repository_url { get; set; }
        public string labels_url { get; set; }
        public string comments_url { get; set; }
        public string events_url { get; set; }
        public string html_url { get; set; }
        public long? id { get; set; }
        public string node_id { get; set; }
        public long? number { get; set; }
        public string title { get; set; }
        public User user { get; set; }
        public Label[] labels { get; set; }
        public string state { get; set; }
        public bool locked { get; set; }
        public Assignee assignee { get; set; }
        public Assignee1[] assignees { get; set; }
        public Milestone milestone { get; set; }
        public long? comments { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object closed_at { get; set; }
        public string author_association { get; set; }
        public object active_lock_reason { get; set; }
        public string body { get; set; }
        public Reactions reactions { get; set; }
        public string timeline_url { get; set; }
        public object performed_via_github_app { get; set; }
        public object state_reason { get; set; }
    }

    public class User
    {
        public string login { get; set; }
        public long? id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

    public class Assignee
    {
        public string login { get; set; }
        public long? id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

    public class Milestone
    {
        public string url { get; set; }
        public string html_url { get; set; }
        public string labels_url { get; set; }
        public long? id { get; set; }
        public string node_id { get; set; }
        public long? number { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Creator creator { get; set; }
        public long? open_issues { get; set; }
        public long? closed_issues { get; set; }
        public string state { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object due_on { get; set; }
        public object closed_at { get; set; }
    }

    public class Creator
    {
        public string login { get; set; }
        public long? id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

    public class Reactions
    {
        public string url { get; set; }
        public long? total_count { get; set; }
        public long? _1 { get; set; }
        public long? laugh { get; set; }
        public long? hooray { get; set; }
        public long? confused { get; set; }
        public long? heart { get; set; }
        public long? rocket { get; set; }
        public long? eyes { get; set; }
    }

    public class Label
    {
        public long? id { get; set; }
        public string node_id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public bool _default { get; set; }
        public string description { get; set; }
    }

    public class Assignee1
    {
        public string login { get; set; }
        public long? id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

}
