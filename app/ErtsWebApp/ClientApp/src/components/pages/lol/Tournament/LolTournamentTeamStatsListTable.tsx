import { Table } from "react-bootstrap";
import { LolTournamentTeamStatsDto } from "../../../../services/GeneratedClient";
import LolTournamentTeamStatsListTableRow from "./LolTournamentTeamStatsListTableRow";

function LolTournamentTeamStatsListTable(props: {
    teamStatsList: LolTournamentTeamStatsDto[] | null;
}) {
    const teamStatsList = props.teamStatsList;

    return (
        <Table striped bordered hover variant="dark">
            <thead>
                <tr>
                    <th style={{ width: "3vh", textAlign: "center" }}></th>
                    <th style={{ width: "5vh", textAlign: "center" }}>Team</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>K</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>D</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>A</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>Gold</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>Dragons</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>Heralds</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>Barons</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>Towers</th>
                    <th style={{ width: "20vh", textAlign: "center" }}>Champs</th>
                </tr>
            </thead>
            <tbody>
                {teamStatsList?.map((teamStats, i) => (
                    <LolTournamentTeamStatsListTableRow teamStats={teamStats} />
                ))}
            </tbody>
        </Table>
    );
}

export default LolTournamentTeamStatsListTable;