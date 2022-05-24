﻿using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public async Task<MediaEdge[]> GetMediaRelationsAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
        {
            new("relations", new GqlSelection[]
            {
                new("edges", GqlParser.ParseType(typeof(MediaEdge)))
            })
        }, new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Media"]["relations"]["edges"].ToObject<MediaEdge[]>();
    }

    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
        {
            new("characters", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("edges", GqlParser.ParseType(typeof(CharacterEdge)))
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        }, new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<CharacterEdge>(
            response["Media"]["characters"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["characters"]["edges"].ToObject<CharacterEdge[]>()
        );
    }

    public async Task<AniPagination<StaffEdge>> GetMediaStaffAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
        {
            new("staff", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("edges", GqlParser.ParseType(typeof(StaffEdge)))
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        }, new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<StaffEdge>(
            response["Media"]["staff"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["staff"]["edges"].ToObject<StaffEdge[]>()
        );
    }

    public async Task<StudioEdge[]> GetMediaStudiosAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
        {
            new("studios", new GqlSelection[]
            {
                new("edges", GqlParser.ParseType(typeof(StudioEdge)))
            })
        }, new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Media"]["studios"]["edges"].ToObject<StudioEdge[]>();
    }

}