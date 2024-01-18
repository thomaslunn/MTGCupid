# MTGCupid

Custom matchmaker for Magic: the Gathering (or similar) tournament play. Written as a WinForms app for .NET 6.0.

## Features

- Unlimited tournament participants
- Supports Swiss, Swiss draft, and Multiplayer variants
- Dropping players mid-tournament
- Saving & loading in-progress and completed tournaments
- "Best possible" pairing algorithm (discussed below)
- Manual pairings override

## Notes on pairings

The official WoTC pairing algorithm naively pairs players with the same winrate that haven't previously played, ignoring OMW%, GW%, OGW% which are used as tiebreakers in the standings.
MTGCupid takes these factors into account, always pairing the current 1st and 2nd ranked players if they have not already played. Failing this, better quality matchups are prioritised for the higher ranked players.
For multiplayer tournaments, games range in size from 3 to 5 players, with 4 player games created wherever possible. Trios of players that have played previously in the tournament are disallowed from being placed into the same game in subsequent rounds. Points can be distributed between all players at the TO's discretion.

## Planned features

- Better draft pods display
- Adding players to the tournament after it has begin
- Ability to modify round pairings after the round is created
- Ability to drop players between rounds
- "WoTC-approved" pairings option
