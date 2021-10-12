import { TournamentShortDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";

function TournamentListTableRow(props: {
	tournament: TournamentShortDto;
	leagueId: number;
}) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}

	const tournament = props.tournament;
	const leagueId = props.leagueId;

	const startTime = tournament.startTime?.format("HH:mm DD-MM-YYYY");
	const endTime = tournament.endTime?.format("HH:mm DD-MM-YYYY");

	return (
		<tr key={tournament.id} data-href="/" onClick={() => redirectToPage(`${leagueId}/${tournament.id}/scoreBoard`)}>
			<td>
				{tournament.name}
			</td>
			<td>{startTime}</td>
			<td>{endTime}</td>
		</tr>
	);
}
export default TournamentListTableRow;
