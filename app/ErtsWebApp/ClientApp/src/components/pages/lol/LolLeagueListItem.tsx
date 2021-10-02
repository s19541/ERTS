import { Container, Row, Col, Image } from "react-bootstrap";

function LolLeagueListItem(props: { leagueImg: any; leagueId: number }) {
	var leagueImg = props.leagueImg;
	var leagueId = props.leagueId;
	return (
		<a href={`lol/${leagueId}`}>
			<Image src={leagueImg} rounded
				width={150}
				height={150} />
		</a>
	);
}

export default LolLeagueListItem;
