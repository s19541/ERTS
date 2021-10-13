import { TournamentShortDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";

function TournamentListTableRow(props: {
	tournament: TournamentShortDto;
	serieId: number;
}) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}

	const tournament = props.tournament;
	const serieId = props.serieId;

	const startTime = tournament.startTime?.format("HH:mm DD-MM-YYYY");
	const endTime = tournament.endTime?.format("HH:mm DD-MM-YYYY");

	return (
		<tr key={tournament.id} data-href="/" onClick={() => redirectToPage(`${serieId}/${tournament.id}/scoreBoard`)}>
			<td>
				{tournament.name}
			</td>
			<td>{startTime}</td>
			<td>{endTime}</td>
		</tr>
	);
}
export default TournamentListTableRow;
