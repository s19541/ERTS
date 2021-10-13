import React from "react";
import { Table } from "react-bootstrap";
import { TournamentShortDto } from "../../../../services/GeneratedClient";
import TournamentListTableRow from "./TournamentListTableRow";

function TournamentListTable(props: {
	tournamentList: TournamentShortDto[] | null;
	serieId: number;
}) {
	const tournaments = props.tournamentList;
	const serieId = props.serieId;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>Tournament</th>
					<th>Start Time</th>
					<th>End Time</th>
				</tr>
			</thead>
			<tbody>
				{tournaments?.map((tournament, i) => (
					<TournamentListTableRow
						tournament={tournament}
						serieId={serieId}
					/>
				))}
			</tbody>
		</Table>
	);
}

export default TournamentListTable;
