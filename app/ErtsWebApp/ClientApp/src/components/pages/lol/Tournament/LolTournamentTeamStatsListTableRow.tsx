import { LolTournamentTeamStatsDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";
import { Image } from "react-bootstrap"

interface IProps {
    teamStats: LolTournamentTeamStatsDto;
}

const LolTournamentTeamStatsListTableRow: React.FunctionComponent<IProps> = (props) => {
    let history = useHistory();
    const redirectToPage = (page: string) => {
        history.push(page);
    }

    const teamStats = props.teamStats;

    return (
        <tr>
            <td onClick={() => redirectToPage(`/lol/team/${teamStats.teamId}`)}
                style={{
                    textAlign: "center",
                    verticalAlign: "middle",
                }}
            >
                <Image
                    src={teamStats.teamImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
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
                <Image
                    src={teamStats.firstRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <Image
                    src={teamStats.secondRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <Image
                    src={teamStats.thirdRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <Image
                    src={teamStats.fourthRecentChampionImageUrl}
                    className=""
                    width={35}
                    height={35}
                />
                <Image
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