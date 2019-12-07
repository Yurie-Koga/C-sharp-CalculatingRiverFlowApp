using System;

class Test {
	static void printTestInfo(int section, double[] width, double[] depth, double[] velocity, double expected, double actual) {
		Console.WriteLine("-Section: ", section);
		Console.WriteLine("-Width: " + string.Join(" ", width));
		Console.WriteLine("-Depth: " + string.Join(" ", depth));
		Console.WriteLine("-Velocity: " + string.Join(" ", velocity));
		Console.WriteLine("-Expected: {0}", expected);
		Console.WriteLine("-Actual  : {0}", actual);
	}

	public void testWithEmptyData() {
		Console.WriteLine("Empty data test:");
		try {
			int section = testEmptyData.getSection();
			double[] width = testEmptyData.getWidth();
			double[] depth = testEmptyData.getDepth();
			double[] velocity = testEmptyData.getVelocity();
			double expected = testEmptyData.getExpected();
			
			RiverFlow rf = new RiverFlow(section, width, depth, velocity);
			double riverFlow = rf.CalculateRiverFlow();

			printTestInfo(section, width, depth, velocity, expected, riverFlow);	
			
			if(riverFlow != expected) throw new Exception("Not expected: testWithEmptyData");
		} catch(Exception) {
			return;
		}
		Console.WriteLine("Empty data test is done...\n");
	}

	static class testEmptyData {
		public static int getSection() { return 0; }
		public static double[] getWidth() {
			double[] arr = {};
			return arr; 
		}
		public static double[] getDepth() {
			double[] arr = {};
			return arr; 
		}
		public static double[] getVelocity() {
			double[] arr = {};
			return arr; 
		}
		public static double getExpected() { return 0; }
	}

	public void testWithSingleData() {
		Console.WriteLine("Single data test:");
		try {
			int section = testSingleData.getSection();
			double[] width = testSingleData.getWidth();
			double[] depth = testSingleData.getDepth();
			double[] velocity = testSingleData.getVelocity();
			double expected = testSingleData.getExpected();
			
			RiverFlow rf = new RiverFlow(section, width, depth, velocity);
			double riverFlow = rf.CalculateRiverFlow();

			printTestInfo(section, width, depth, velocity, expected, riverFlow);	

			if(riverFlow != expected) throw new Exception("Not expected: testWithSingleData");
		} catch(Exception) {
			return;
		}
		Console.WriteLine("Single data test is done...\n");
	}

	static class testSingleData {
		public static int getSection() { return 1; }
		public static double[] getWidth() {
			double[] arr = { 1.2 };
			return arr; 
		}
		public static double[] getDepth() {
			double[] arr = { 3.4 };
			return arr; 
		}
		public static double[] getVelocity() {
			double[] arr = { 5.6 };
			return arr; 
		}
		public static double getExpected() { return 22.848; }
	}

	public void testWithMultipleData() {
		Console.WriteLine("Multiple data test:");
		try {
			int section = testMultipleData.getSection();
			double[] width = testMultipleData.getWidth();
			double[] depth = testMultipleData.getDepth();
			double[] velocity = testMultipleData.getVelocity();
			double expected = testMultipleData.getExpected();
			
			RiverFlow rf = new RiverFlow(section, width, depth, velocity);
			double riverFlow = rf.CalculateRiverFlow();

			printTestInfo(section, width, depth, velocity, expected, riverFlow);	

			if(riverFlow != expected) throw new Exception("Not expected: testWithMultipleData");
		} catch(Exception) {
			return;
		}
		Console.WriteLine("Multiple data test is done...\n");
	}

	static class testMultipleData {
		public static int getSection() { return 3; }
		public static double[] getWidth() {
			double[] arr = { 10.1, 10.2, 10.3 };
			return arr; 
		}
		public static double[] getDepth() {
			double[] arr = { 11.1, 11.2, 11.3 };
			return arr; 
		}
		public static double[] getVelocity() {
			double[] arr = { 12.1, 12.2, 12.3 };
			return arr; 
		}
		public static double getExpected() { return 4181.856; }
	}

	public void testWithMixedDataType() {
		Console.WriteLine("Mixed data type test:");
		try {
			int section = testMixedDataType.getSection();
			double[] width = testMixedDataType.getWidth();
			double[] depth = testMixedDataType.getDepth();
			double[] velocity = testMixedDataType.getVelocity();
			double expected = testMixedDataType.getExpected();
			
			RiverFlow rf = new RiverFlow(section, width, depth, velocity);
			double riverFlow = rf.CalculateRiverFlow();

			printTestInfo(section, width, depth, velocity, expected, riverFlow);	

			if(riverFlow != expected) throw new Exception("Not expected: testWithMixedDataType");
		} catch(Exception) {
			return;
		}
		Console.WriteLine("Mixed data type test is done...\n");
	}

	static class testMixedDataType {
		public static int getSection() { return 3; }
		public static double[] getWidth() {
			double[] arr = { 5.7, 8, 11.2 };
			return arr; 
		}
		public static double[] getDepth() {
			double[] arr = { 4, 6.9, 3 };
			return arr; 
		}
		public static double[] getVelocity() {
			double[] arr = { 3.4, 21.5, 18.0 };
			return arr; 
		}
		public static double getExpected() { return 1869.12; }
	}
}

class TestMainClass {
	public static void TestMain () {
		Test test = new Test();
		Console.WriteLine("Test has started!...");
		test.testWithEmptyData();			
		test.testWithSingleData();		
		test.testWithMultipleData();
		test.testWithMixedDataType();		
		Console.WriteLine("All tests are completed!!");
	}
}