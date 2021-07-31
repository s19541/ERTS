import React from "react";
import { Table } from "react-bootstrap";
import { TournamentShortDto } from "../../../services/GeneratedClient";
import LolTournamentListTableRow from "./LolTournamentListTableRow";

function CarListTable(props: { tournamentList: TournamentShortDto[] | null }) {
	const tournaments = props.tournamentList;
	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>Name</th>
					<th>Start Time</th>
					<th>End Time</th>
				</tr>
			</thead>
			<tbody>
				{tournaments?.map((tournament, i) => (
					<LolTournamentListTableRow tournament={tournament} />
				))}
			</tbody>
		</Table>
	);
}

export default CarListTable;
