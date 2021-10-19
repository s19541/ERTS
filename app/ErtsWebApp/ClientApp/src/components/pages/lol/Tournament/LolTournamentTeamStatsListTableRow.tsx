import { LolTournamentTeamStatsDto } from "../../../../services/GeneratedClient";

function LolTournamentTeamStatsListTableRow(props: {
    teamStats: LolTournamentTeamStatsDto;
}) {
    const teamStats = props.teamStats;

    return (
        <tr>
            <td
                style={{
                    textAlign: "center",
                    verticalAlign: "middle",
                }}
            >
                <img
                    src={teamStats.teamImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
            </td>
            <td
                style={{
                    textAlign: "center",
                    verticalAlign: "middle",
                }}
            >
                {teamStats.teamName}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.kills}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.deaths}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.assists}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.gold}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.dragons}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.heralds}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.barons}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                {teamStats.towers}
            </td>
            <td
                style={{
                    verticalAlign: "middle",
                    textAlign: "center",
                }}
            >
                <img
                    src={teamStats.firstRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <img
                    src={teamStats.secondRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <img
                    src={teamStats.thirdRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <img
                    src={teamStats.fourthRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <img
                    src={teamStats.fivethRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
            </td>
        </tr>
    );
}
export default LolTournamentTeamStatsListTableRow;