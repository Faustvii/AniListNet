﻿using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public async Task<MediaTag[]> GetMediaTagsAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("tags", typeof(MediaTag).ToSelections())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["tags"].ToObject<MediaTag[]>();
    }

    public async Task<MediaRelationEdge[]> GetMediaRelationsAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("relations", new GqlSelection[]
            {
                new("edges", typeof(MediaRelationEdge).ToSelections())
            })
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["relations"]["edges"].ToObject<MediaRelationEdge[]>();
    }

    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int mediaId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("characters", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(CharacterEdge).ToSelections())
            }, new GqlParameter[]
            {
                new("sort", CharacterSort.Role)
            }.Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<CharacterEdge>(
            response["Media"]["characters"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["characters"]["edges"].ToObject<CharacterEdge[]>()
        );
    }

    public async Task<AniPagination<StaffEdge>> GetMediaStaffAsync(int mediaId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("staff", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(StaffEdge).ToSelections())
            }, paginationOptions.ToParameters())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<StaffEdge>(
            response["Media"]["staff"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["staff"]["edges"].ToObject<StaffEdge[]>()
        );
    }

    public async Task<StudioEdge[]> GetMediaStudiosAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("studios", new GqlSelection[]
            {
                new("edges", typeof(StudioEdge).ToSelections())
            })
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["studios"]["edges"].ToObject<StudioEdge[]>();
    }

    /* below is properties specific for the authenticated user */

    public async Task<MediaEntry?> GetMediaEntryAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("mediaListEntry", typeof(MediaEntry).ToSelections())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["mediaListEntry"].ToObject<MediaEntry?>();
    }

}