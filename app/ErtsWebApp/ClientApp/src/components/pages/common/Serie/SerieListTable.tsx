import { Table } from "react-bootstrap";
import { SerieShortDto } from "../../../../services/GeneratedClient";
import SerieListTableRow from "./SerieListTableRow";

function SerieListTable(props: {
	serieList: SerieShortDto[] | null;
	leagueId: number;
}) {
	const series = props.serieList;
	const leagueId = props.leagueId;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>Serie</th>
					<th>Start Time</th>
					<th>End Time</th>
				</tr>
			</thead>
			<tbody>
				{series?.map((serie, i) => (
					<SerieListTableRow
						serie={serie}
						leagueId={leagueId}
					/>
				))}
			</tbody>
		</Table>
	);
}

export default SerieListTable;
