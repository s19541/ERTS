import { Table } from "react-bootstrap";
import { TournamentTeamShortDto } from "../../../../services/GeneratedClient";
import LolTournamentTeamTableRow from "./LolTournamentTeamTableRow";

function LolTournamentTeamTable(props: {
	tournamentTeamList: TournamentTeamShortDto[] | null;
}) {
	const tournamentTeams = props.tournamentTeamList;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th style={{ width: "5vh", textAlign: "center" }}>#</th>
					<th>Team</th>
					<th>Series</th>
					<th>Games</th>
				</tr>
			</thead>
			<tbody>
				{tournamentTeams?.map((tournamentTeam, i) => (
					<LolTournamentTeamTableRow
						position={i}
						tournamentTeam={tournamentTeam}
					/>
				))}
			</tbody>
		</Table>
	);
}

export default LolTournamentTeamTable;
