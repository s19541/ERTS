import { SerieShortDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";

function SerieListTableRow(props: {
	serie: SerieShortDto;
	leagueId: number;
}) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}

	const serie = props.serie;
	const leagueId = props.leagueId;

	const startTime = serie.startTime?.format("HH:mm DD-MM-YYYY");
	const endTime = serie.endTime?.format("HH:mm DD-MM-YYYY");

	return (
		<tr key={serie.id} data-href="/" onClick={() => redirectToPage(`${leagueId}/${serie.id}`)}>
			<td>
				{serie.name}
			</td>
			<td>{startTime}</td>
			<td>{endTime}</td>
		</tr>
	);
}
export default SerieListTableRow;
